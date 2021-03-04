using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Admin
{
    public class CustomValidator : ComponentBase
    {
        private ValidationMessageStore messageStore;
        [CascadingParameter]
        private EditContext EntryContext { get; set; }

        protected override void OnInitialized()
        {
            if (EntryContext == null)
            {
                throw new InvalidOperationException(
                $"{nameof(CustomValidator)} requires a cascading " +
                $"parameter of type {nameof(EditContext)}. " +
                $"For example, you can use {nameof(CustomValidator)} " +
                $"inside an {nameof(EditForm)}.");
            }

            messageStore = new ValidationMessageStore(EntryContext);

            EntryContext.OnValidationRequested += (s, e) => messageStore.Clear();
            EntryContext.OnFieldChanged += (s, e) => messageStore.Clear(e.FieldIdentifier);
        }

        public void DisplayErrors(Dictionary<string, List<string>> errors)
        {
            foreach (var err in errors)
            {
                messageStore.Add(EntryContext.Field(err.Key), err.Value);
            }

            EntryContext.NotifyValidationStateChanged();
        }

        public void ClearErrors()
        {
            messageStore.Clear();
            EntryContext.NotifyValidationStateChanged();
        }
    }
}
