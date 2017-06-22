namespace MLNotification.ConsoleClient
{
    using System;
    using MLNotification.ServiceClientConnect;
    using MLNotification.Domain;
    using static System.Console;
    using static System.Threading.Thread;
    using System.Threading.Tasks;

    internal class Processor
    {
        public MLMessageHubConect connectHub;

        internal void Start()
        {
            var userInfo = new UserInfo { User = "Trnasfer APP CMD", Server = "localhost" };

            //System.Threading.Thread.Sleep(5000);

            connectHub = BuilderMLMessageHubConnect.CreateMLMessageHub("http://localhost:11111", userInfo);


            string messageInitial  = "#######################################################################";
            string messageInitial2 = "###                                                                 ###";
            string messageInitial3 = "###                      TRANSACTIONS APP CMD                       ###";

            WriteLine(messageInitial);
            WriteLine(messageInitial);
            WriteLine(messageInitial2);
            WriteLine(messageInitial3);
            WriteLine(messageInitial2);
            WriteLine(messageInitial);
            WriteLine(messageInitial);

            WriteLine(Environment.NewLine + Environment.NewLine);

            string tn1 = "548524552_77.3362";
            string tn2 = "999999999_99.9999";

            Transfer(tn1);
            Transfer(tn2);

            WriteLine("Finalizeddd !!!!");
            WriteLine("Tuch any key to close");

            Read();

            connectHub.Dispose();
        }

        public async void SendMessage(bool condition, string transactionNumber, MessageType messageType)
        {
            string subject = $"Transaction {transactionNumber}";
            string body = condition ? $"The Transaction {transactionNumber} has been sended" : $"The Transaction {transactionNumber} has been aborted";


            var message = new NotificationMessage { Subject = subject, Body = body, User = "CMD usr", MessageDate = DateTime.Now, Server = "Server Local", UriImage = "http://files.softicons.com/download/system-icons/atrous-windows-7-icons-by-iconleak/png/256x256/10.png" };

            message.MessageType = messageType;
    

            await connectHub.SendMessage(message);
        }


        public void Transfer(string numberTransfer)
        {
            WriteLine($"Can you send the transaction {numberTransfer} ?? <Y/N>");

            string resp = string.Empty;

            resp = ReadLine();

            SendMessage(resp?.ToUpper() == "Y", numberTransfer, resp?.ToUpper() == "Y" ? MessageType.VeryImportant : MessageType.Warnnig);
        }


        public void Start2()
        {
            Read();

            connectHub = BuilderMLMessageHubConnect.CreateMLMessageHub("http://localhost:11111");

            //Sleep(3000);

            NotificationMessage message = null;

            message = new NotificationMessage
            {
                Subject = "Example Information",
                Body = "Example Information",
                Server = "localhost",
                User = "User",
                MessageType = MessageType.Information,
                UriImage = "http://www.pearltrees.com/s/pic/or/example-70680304"
            };

            Task.WaitAll(connectHub.SendMessage(message));

            Sleep(1000);

            message = new NotificationMessage
            {
                Subject = "Example Warning",
                Body = "Example Warining",
                Server = "localhost",
                User = "User",
                MessageType = MessageType.Warnnig,
                UriImage = "http://www.pearltrees.com/s/pic/or/example-70680304"
            };

            Task.WaitAll(connectHub.SendMessage(message));

            Sleep(1000);

            message = new NotificationMessage
            {
                Subject = "Example Error",
                Body = "Example Error",
                Server = "localhost",
                User = "User",
                MessageType = MessageType.Error,
                UriImage = "http://www.pearltrees.com/s/pic/or/example-70680304"
            };

            Task.WaitAll(connectHub.SendMessage(message));

            Sleep(1000);

            message = new NotificationMessage
            {
                Subject = "Example Very Important",
                Body = "Example Very Important",
                Server = "localhost",
                User = "User",
                MessageType = MessageType.VeryImportant,
                UriImage = "http://www.pearltrees.com/s/pic/or/example-70680304"
            };

            Task.WaitAll(connectHub.SendMessage(message));

            Sleep(2000);

            message = new NotificationMessage
            {
                Subject = "Example Urgent Information",
                Body = "Example Urgent Information",
                Server = "localhost",
                User = "User",
                MessageType = MessageType.Information_urgent,
                UriImage = "http://www.pearltrees.com/s/pic/or/example-70680304"
            };

            Task.WaitAll(connectHub.SendMessage(message));

            Sleep(1000);

            message = new NotificationMessage
            {
                Subject = "Example Urgent Warning",
                Body = "Example Urgent Warining",
                Server = "localhost",
                User = "User",
                MessageType = MessageType.Warnnig_urgent,
                UriImage = "http://www.pearltrees.com/s/pic/or/example-70680304"
            };

            Task.WaitAll(connectHub.SendMessage(message));

            Sleep(1000);

            message = new NotificationMessage
            {
                Subject = "Example Urgent Error",
                Body = "Example Urgent Error",
                Server = "localhost",
                User = "User",
                MessageType = MessageType.Error_urgent,
                UriImage = "http://www.pearltrees.com/s/pic/or/example-70680304"
            };

            Task.WaitAll(connectHub.SendMessage(message));

            Sleep(1000);

            message = new NotificationMessage
            {
                Subject = "Example Urgent Very Important",
                Body = "Example Urgent Very Important",
                Server = "localhost",
                User = "User",
                MessageType = MessageType.VeryImportant_urgent,
                UriImage = "http://www.pearltrees.com/s/pic/or/example-70680304"
            };

            Task.WaitAll(connectHub.SendMessage(message));


            Read();

            //connectHub.Dispose();
        }


        //public async void SendMessagePrueba(NotificationMessage message)
        //{
        //    string subject = $"Transaction {transactionNumber}";
        //    string body = condition ? $"The Transaction {transactionNumber} has been sended" : $"The Transaction {transactionNumber} has been aborted";


        //    var message = new NotificationMessage { Subject = subject, Body = body, User = "CMD usr", MessageDate = DateTime.Now, Server = "Server Local", UriImage = "http://files.softicons.com/download/system-icons/atrous-windows-7-icons-by-iconleak/png/256x256/10.png" };

        //    message.MessageType = messageType;


        //    await connectHub.SendMessage(message);
        //}
    }
}