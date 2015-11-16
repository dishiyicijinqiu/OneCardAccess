using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace FengSharp.OneCardAccess.Infrastructure.Session_Policy
{
    internal class SessionClientMessageInspector : IClientMessageInspector
    {
        private SessionMessageHeaderInfo messageheaderinfo;
        public SessionClientMessageInspector(SessionMessageHeaderInfo messageheaderinfo)
        {
            this.messageheaderinfo = messageheaderinfo;
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            if (AuthPrincipal.CurrentAuthPrincipal != null && !string.IsNullOrWhiteSpace(AuthPrincipal.CurrentAuthPrincipal.Ticket))
            {
                request.Headers.Add(MessageHeader.CreateHeader(this.messageheaderinfo.TicketName,
                    this.messageheaderinfo.Namespace, AuthPrincipal.CurrentAuthPrincipal.Ticket));
            }
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            //int ticketheaderindex = reply.Headers.FindHeader(messageheaderinfo.TicketName, messageheaderinfo.Namespace);
            //if (ticketheaderindex > -1)
            //{
            //    var ticketstring = reply.Headers.GetHeader<string>(messageheaderinfo.TicketName, messageheaderinfo.Namespace);
            //    System.Threading.Thread.CurrentPrincipal = new AuthPrincipal(Thread.CurrentPrincipal.Identity)
            //    {
            //        Ticket = ticketstring
            //    };
            //}
        }
    }
}
