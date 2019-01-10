using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.WebApi.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="value"></param>
        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
