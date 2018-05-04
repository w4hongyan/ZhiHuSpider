using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhiHuSpider
{

    public class Paging
    {
        /// <summary>
        /// 
        /// </summary>
        public string is_end { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int totals { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string previous { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_start { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string next { get; set; }
    }

    public class Unnormal_details
    {
    }

    public class Suggest_edit
    {
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Unnormal_details unnormal_details { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tip { get; set; }
    }

    public class Relationship
    {
        /// <summary>
        /// 
        /// </summary>
       // public List<string> upvoted_followees { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_nothelp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_authorized { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int voting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_thanked { get; set; }
    }

    public class Can_comment
    {
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string reason { get; set; }
    }

    public class BadgeInfo
    {
        public string type { get; set; }
        public string description { get; set; }
    }
    public class Author
    {
        /// <summary>
        /// 
        /// </summary>
        public string avatar_url_template { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<BadgeInfo> badge { get; set; }
        /// <summary>
        /// 机械之芯
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string headline { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string user_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_advertiser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avatar_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_org { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int follower_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url_token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
    }

    public class Question
    {
        /// <summary>
        /// 
        /// </summary>
        public string question_type { get; set; }
        /// <summary>
        /// 如何看待 Python 进入山东小学课本？会推广到其他地区吗？
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string created { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int updated_time { get; set; }
    }

    public class Reward_info
    {
        /// <summary>
        /// 
        /// </summary>
        public int reward_member_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_rewardable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int reward_total_money { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string can_open_reward { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tagline { get; set; }
    }

    public class MarkInfo
    {
        public string mark_type { get; set; }
    }
    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Suggest_edit suggest_edit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Relationship relationship { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string editable_content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MarkInfo> mark_infos { get; set; }
        /// <summary>
        /// 学之前起码得学过计算机基础啊，真的跟传统科目死记硬背还有意义吗
        /// </summary>
        public string excerpt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> annotation_action { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string admin_closed_comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string collapsed_by { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Can_comment can_comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int created_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int voteup_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string collapse_reason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_collapsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_sticky { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string comment_permission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Author author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Question question { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updated_time { get; set; }
        /// <summary>
        /// 学之前起码得学过计算机基础啊，真的跟传统科目死记硬背还有意义吗
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int comment_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extras { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string reshipment_settings { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Reward_info reward_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_copyable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string thumbnail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_normal { get; set; }
    }

    public class PageInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Paging paging { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
    }
}
