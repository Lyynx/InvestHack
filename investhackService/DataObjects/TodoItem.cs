using Microsoft.WindowsAzure.Mobile.Service;

namespace investhackService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}