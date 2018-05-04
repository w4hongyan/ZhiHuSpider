using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Answer
    {
        public int id { get; set; }
        public string questionid { get; set; }
        public string answerid { get; set; }
        public string answercontent { get; set; }
        public string answertext { get; set; }
        public string authorid { get; set; }
        public string authorname { get; set; }
        public int voteup { get; set; }
        public string updatetime { get; set; }

    }
}
