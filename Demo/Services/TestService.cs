namespace Demo.Services
{
    public class TestService
    {
        public string SayHello(string name)
        {
            return $"Hello {name}";
        }

        public string AddName(string name)
        {
            return "添加成功！";
        }
    }
}
