using System.Linq;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace JustSaying.AwsTools
{
    public class SqsQueueByUrl : SqsQueueBase
    {
        public SqsQueueByUrl(string queueUrl, IAmazonSQS client)
            : base(client)
        {
            Url = queueUrl;
        }

        public override bool Exists()
        {
            var result = Client.ListQueues(new ListQueuesRequest());
            if (result.QueueUrls.Any(x => x == Url))
            {
                SetArn();
                // Need to set the prefix yet!
                return true;
            }

            return false;
        }
    }
}