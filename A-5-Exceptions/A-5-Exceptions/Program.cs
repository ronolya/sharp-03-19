using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Lesson_5
{
    public partial class  Program
    {
        static void Main(string[] args)
        {
            //AdultException();
            //AsyncAwaitException();
            AsyncExceptionUnObservedExample();
            //AsyncExceptionObservedExample();
            Console.ReadLine();
        }

        public static void GenerateExceptionExample()
        {
            double credit1 = CreditCalculator.GetPaymentPerMonth(500, 12, 24);

            double credit2 = CreditCalculator.GetPaymentPerMonth(0, 12, 24);

            double credit3 = CreditCalculator.GetPaymentPerMonth(500, 0, 24);

            double credit4 = CreditCalculator.GetPaymentPerMonth(500, 12, 0);

        }

        public static async Task MakeRequestWithNotModifiedSupport()
        {
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://tut.by");

            var responseText = string.Empty;

            try
            {
                responseText = await streamTask;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                responseText = "Site Moved";
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("304"))
            {
                responseText =  "Use the Cache";
            }
        }

        public static void MultipleExceptionCatcher()
        {
            try
            {
                int number = 25;
                int[] deviders = new int[] { 3, 6, 0 };

                for (int i = 0; i <= deviders.Length; i++)
                {
                    var result = number / deviders[i];
                    Console.Write(result);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.Write(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.Write(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static void InnerTryCatchExample()
        {
            try
            {
                int number = 25;
                int[] deviders = new int[] { 3, 6, 0 };

                for (int i = 0; i <= deviders.Length; i++)
                {
                    try
                    {
                        var result = number / deviders[i];
                        Console.Write(result);
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.Message);
                    }                   
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.Write(ex.Message);
            }           
        }

        public static void ClrExceptionCatcher()
        {
            try
            {
                var zero = 0;
                var number = 25;

                var result = number / zero;
                Console.Write(result);
            }
            catch (Exception ex) {
                Console.Write(ex.Message);
            }
        }

        public static void ExceptionFinallyExample()
        {
            try
            {
                var zero = 0;
                var number = 25;

                var result = number / zero;
                Console.Write(result);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                //do some code here. 
            }
        }

        public static void EmptyExceptionCatcher()
        {
            try
            {
                var zero = 0;
                var number = 25;

                var result = number / zero;
                Console.Write(result);
            }
            catch {}
        }

        public static void AdultException()
        {
            const int adult = 18;

            var birthDate = new DateTime(2004, 2, 29);
            var adultDate = new DateTime(birthDate.Year + adult, birthDate.Month, birthDate.Day);

            Console.WriteLine(adultDate);
        }

        public static void ThrowExceptionExample()
        {
            throw new System.Net.Mail.SmtpException();
        }

        //public SmtpException();

        //public SmtpException(SmtpStatusCode statusCode);

        //public SmtpException(string message);

        //public SmtpException(SmtpStatusCode statusCode, string message);

        //public SmtpException(string message, Exception innerException);

        public enum SmtpStatusCode
        {
            GeneralFailure = -1,
            SystemStatus = 211,
            HelpMessage = 214,
            ServiceReady = 220,
            ServiceClosingTransmissionChannel = 221,
            Ok = 250,
            UserNotLocalWillForward = 251,
            CannotVerifyUserWillAttemptDelivery = 252,
            StartMailInput = 354,
            ServiceNotAvailable = 421,
            MailboxBusy = 450,
            LocalErrorInProcessing = 451,
            InsufficientStorage = 452,
            ClientNotPermitted = 454,
            CommandUnrecognized = 500,
            SyntaxError = 501,
            CommandNotImplemented = 502,
            BadCommandSequence = 503,
            CommandParameterNotImplemented = 504,
            MustIssueStartTlsFirst = 530,
            MailboxUnavailable = 550,
            UserNotLocalTryAlternatePath = 551,
            ExceededStorageAllocation = 552,
            MailboxNameNotAllowed = 553,
            TransactionFailed = 554
        }
    }
}
