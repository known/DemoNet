using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.WebSockets;

namespace Demo.Web.Html5
{
    public class WebSocketManager
    {
        private WebSocket socket;

        public WebSocketManager()
        {
        }

        public WebSocketManager(WebSocket socket)
        {
            this.socket = socket;
        }

        public static async Task RunTask(AspNetWebSocketContext context, Action<WebSocketManager> action)
        {
            var socket = context.WebSocket;
            if (socket.State == WebSocketState.Open)
            {
                var wsm = new WebSocketManager(socket);
                try
                {
                    action(wsm);
                }
                catch (Exception ex)
                {
                    await wsm.SendMessageAsync(ex.Message);
                }
            }
        }

        public Task SendMessageAsync(string message)
        {
            var content = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            return socket.SendAsync(content, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        #region Chat
        private static Dictionary<string, WebSocket> connectPool = new Dictionary<string, WebSocket>();
        private static Dictionary<string, List<MessageInfo>> messagePool = new Dictionary<string, List<MessageInfo>>();

        public async Task ProcessMessage(AspNetWebSocketContext context)
        {
            var socket = context.WebSocket;
            var userName = context.User.Identity.Name;

            try
            {
                UpdateConnectPool(userName, socket);
                //发送离线消息
                ProcessMessagePool(userName, socket);

                var destUser = string.Empty;
                while (true)
                {
                    if (socket.State != WebSocketState.Open)
                    {
                        break;
                    }
                    else
                    {
                        var buffer = new ArraySegment<byte>(new byte[2048]);
                        var result = await socket.ReceiveAsync(buffer, CancellationToken.None);

                        if (socket.State != WebSocketState.Open)
                        {
                            RemoveConnect(userName);
                            break;
                        }

                        var userMsg = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                        var msgList = userMsg.Split('|');
                        if (msgList.Length == 2)
                        {
                            if (msgList[0].Trim().Length > 0)
                                destUser = msgList[0].Trim();//记录消息目的用户
                            buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(msgList[1]));
                        }
                        else
                        {
                            buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(userMsg));
                        }

                        if (connectPool.ContainsKey(destUser))//判断客户端是否在线
                        {
                            var destSocket = connectPool[destUser];
                            if (destSocket != null && destSocket.State == WebSocketState.Open)
                                await SendMessageAsync(destSocket, buffer);
                        }
                        else
                        {
                            await Task.Run(() =>
                            {
                                 if (!messagePool.ContainsKey(destUser))//将用户添加至离线消息池中
                                    messagePool.Add(destUser, new List<MessageInfo>());
                                 messagePool[destUser].Add(new MessageInfo(DateTime.Now, buffer));//添加离线消息
                            });
                        }
                    }
                }
            }
            catch
            {
                RemoveConnect(userName);
            }
        }

        private void UpdateConnectPool(string key, WebSocket socket)
        {
            if (!connectPool.ContainsKey(key))
            {
                connectPool.Add(key, socket);
            }
            else
            {
                if (socket != connectPool[key])
                    connectPool[key] = socket;
            }
        }

        private void RemoveConnect(string key)
        {
            if (connectPool.ContainsKey(key))
            {
                connectPool.Remove(key);
            }
        }

        private async void ProcessMessagePool(string key, WebSocket socket)
        {
            if (messagePool.ContainsKey(key))
            {
                var messages = messagePool[key];
                foreach (var item in messages)
                {
                    await SendMessageAsync(socket, item.Content);
                }
                messagePool.Remove(key);
            }
        }

        private async Task SendMessageAsync(WebSocket socket, ArraySegment<byte> content)
        {
            await socket.SendAsync(content, WebSocketMessageType.Text, true, CancellationToken.None);
        }
        #endregion
    }
}
