using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntryCustomReturn.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace Agate.Infrastructure
{
    public static class FormHelpers
    {
        public static void ChainEntries(params VisualElement[] entries)
        {
            if(entries.Length == 0)
                return;

            for (int i = 0; i < entries.Length-1; i++)
            {
                var current = entries[i];
                var next = entries[i + 1];

                CustomReturnEffect.SetReturnType(current, ReturnType.Next);
                CustomReturnEffect.SetReturnCommand(current, new Command(x => next.Focus()));

                if(current is Picker picker)
                {
                    picker.SelectedIndexChanged += (sender, args) => next.Focus();
                }
            }

            var lastEntry = entries.Last();
            CustomReturnEffect.SetReturnType(lastEntry, ReturnType.Done);
        }
    }
}
