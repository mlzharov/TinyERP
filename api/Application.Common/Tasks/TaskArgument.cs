namespace App.Common.Tasks
{
    public class TaskArgument<TContent>
    {
        public TContent Data { get; private set; }
        public ApplicationType Type { get; private set; }
        public TaskArgument(TContent content, ApplicationType type)
        {
            this.Data = content;
            this.Type = type;
        }
    }
}
