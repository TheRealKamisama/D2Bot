using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Web;
using Newbe.Mahua;
using Newbe.Mahua.MahuaEvents;
using TextCommandCore;
using TRKS.D2.QQBot;
using static TRKS.D2.QQBot.Messenger;
using Number = System.Numerics.BigInteger;

namespace TRKS.D2.QQBot.MahuaEvents
{
    /// <summary>
    /// 群消息接收事件
    /// </summary>
    public class GroupMessageReceivedMahuaEvent1
        : IGroupMessageReceivedMahuaEvent
    {
        private readonly IMahuaApi _mahuaApi;

        public GroupMessageReceivedMahuaEvent1(
            IMahuaApi mahuaApi)
        {
            _mahuaApi = mahuaApi;
        }

        public void ProcessGroupMessage(GroupMessageReceivedContext context)
        {


            Task.Factory.StartNew(() =>
            {
                var message = HttpUtility.HtmlDecode(context.Message)?.ToLower();

                message = message.StartsWith("!") ? message.Substring(1) : message;

                var handler = new GroupMessageHandler(context.FromQq.ToHumanQQNumber(), context.FromGroup.ToGroupNumber(), message);
                var (matched, result) = handler.ProcessCommandInput();
            }, TaskCreationOptions.LongRunning);
        }
    }

    public partial class GroupMessageHandler
    {
        [Matchers("查询噶点")]
        void SearchGuardian(string name)
        {
            _d2Status.SendPlayerinfos(Group, name);
        }
    }

    public partial class GroupMessageHandler : ICommandHandler<GroupMessageHandler>, ISender
    {
        public Action<TargetID, Message> MessageSender { get; }
        public Action<Message> ErrorMessageSender { get; }

        public HumanQQNumber Sender { get; }
        public string Message { get; }
        public GroupNumber Group { get; }

        private D2Status _d2Status = new D2Status();
        
        string ICommandHandler<GroupMessageHandler>.Sender => Group.QQ;



        public GroupMessageHandler(HumanQQNumber sender, GroupNumber group, string message)
        {
            Sender = sender;
            MessageSender = (id, msg) =>
            {
                SendGroup(id.ID.ToGroupNumber(), msg);
                Trace.WriteLine($"Message Processed: Group [{Group}], QQ [{Sender}], Message Content [{message}], Result [{msg.Content}].", "Message");

            };
            Group = group;
            Message = message;

            ErrorMessageSender = msg => SendDebugInfo(msg);
        }

    }
}
