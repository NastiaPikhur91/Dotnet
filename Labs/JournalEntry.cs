using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class JournalEntry
    {

        public string CollectionName { get; set; }
        public string Type { get; set; }
        public string StudentInfo { get; set; }


        public JournalEntry()
        {
            CollectionName = string.Empty;
            Type = string.Empty;
        }

        public override string ToString()
        {
            return $"[TeamsJournalEntry: CollectionName={CollectionName}, Type={Type}, StudentInfo={StudentInfo}]";
        }
    }
}
