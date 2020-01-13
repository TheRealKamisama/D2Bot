using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GammaLibrary.Extensions;
using Newbe.Mahua;
using Newbe.Mahua.Internals;
using Newbe.Mahua.MahuaEvents;
using TextCommandCore;
using TRKS.D2.QQBot;
using Number = System.Numerics.BigInteger;
using static TRKS.D2.QQBot.Messenger;

namespace TRKS.D2.QQBot.MahuaEvents
{
    /// <summary>
    /// 私聊消息接收事件
    /// </summary>
    public class PrivateMessageReceivedMahuaEvent2
        : IPrivateMessageReceivedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;
        
        public PrivateMessageReceivedMahuaEvent2(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessPrivateMessage(PrivateMessageReceivedContext context)
        {

            new PrivateMessageHandler(context.FromQq.ToHumanQQNumber(), context.Message).ProcessCommandInput();
            //                SendPrivate(context.FromQq, "您群号真牛逼."); // 看一次笑一次 6 皮笑肉不笑
        }
    }


    public partial class PrivateMessageHandler
    {
        private List<GroupInfo> GetGroups()
        {
            using (var robotSession = MahuaRobotManager.Instance.CreateSession())
            {
                var mahuaApi = robotSession.MahuaApi;
                var groups = mahuaApi.GetGroupsWithModel().Model.ToList();
                return groups;
            }
        }

    }

    public partial class PrivateMessageHandler : ICommandHandler<PrivateMessageHandler>, ISender
    {
        public Action<TargetID, Message> MessageSender { get; } = (id, msg) => SendPrivate(id.ID.ToHumanQQNumber(), msg);
        public Action<Message> ErrorMessageSender { get; } = msg => SendDebugInfo(msg);
        public HumanQQNumber Sender { get; }
        public string Message { get; }

        string ICommandHandler<PrivateMessageHandler>.Sender => Sender.QQ;

        public PrivateMessageHandler(HumanQQNumber sender, string message)
        {
            Sender = sender;
            Message = message;
        }
    }
}
