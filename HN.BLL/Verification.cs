using HN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HN.BLL
{
    public class Verification
    {
        private readonly DAL.Verification dal = new DAL.Verification();
        public Verification()
        { }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public IEnumerable<Model.Verification> Query(VerificationType type, string to)
        {
            return dal.Query(type, to);
        }

        /// <summary>
        /// 创建验证
        /// </summary>
        /// <param name="type"></param>
        /// <param name="to"></param>
        /// <param name="verifyCode"></param>
        /// <param name="dateCreated"></param>
        public void Create(VerificationType type, string to)
        {
            string chkCode = string.Empty;
            //验证码的字符集，去掉了一些容易混淆的字符 
            char[] character = { '2', '3', '4', '5', '6', '8', '9', 'a', 'b', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 'x', 'y', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            Random rnd = new Random();
            //生成验证码字符串 
            for (int i = 0; i < 4; i++)
            {
                chkCode += character[rnd.Next(character.Length)];
            }
            Model.Verification entity = new Model.Verification() { Type = type, To = to, VerifyCode = chkCode, DateCreated = DateTime.Now };
            if (type == VerificationType.Phone)
            {
                UCSRestRequest.UCSRestRequest api = new UCSRestRequest.UCSRestRequest();
                string serverIp = "api.ucpaas.com";
                string serverPort = "443";
                string account = "e5bbac9f08b8900cb5c5e488f792cc0b";    //用户sid
                string token = "3499976b631aed9120c1106d8b9dc694";      //用户sid对应的token
                string appId = "bbcfd83149ab4016a89f9208f8a41b50";      //对应的应用id，非测试应用需上线使用

                api.init(serverIp, serverPort);
                api.setAccount(account, token);
                api.enabeLog(true);
                api.setAppId(appId);
                api.enabeLog(true);

                //短信
                api.SendSMS(entity.To, "48224", entity.VerifyCode);
            }
            dal.Create(entity);
        }
    }
}
