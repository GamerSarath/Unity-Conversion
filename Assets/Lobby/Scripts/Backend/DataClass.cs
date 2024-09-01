using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class DataClass
{
    public string username;

    public string password;

    public string store_id;

    public int dev;

}

[System.Serializable]
public class LoginData
{
    public bool status;
    public int userid;
    public string api_token;
    public string usercredit;
    public string username;
    public int useragent;
    public int userstocke;
    public string name;
    public List<object> blockedgames;
    public string welcome_message;
    public string gameversion;
}

[System.Serializable]
public class TrippleChanceStartGameData
{
    public string usercredit;
    public int tripple_gameplay;
    public bool status;
    public int tripple_uniqid;
    public int tripple_gametime;
    public int tripple_total_bet;
    public List<int> tripple_single_bets;
    public List<int> tripple_bets0;
    public List<int> tripple_bets1;
    public List<int> tripple_bets2;
    public List<int> tripple_bets3;
    public List<int> tripple_bets4;
    public List<int> tripple_bets5;
    public List<int> tripple_bets6;
    public List<int> tripple_bets7;
    public List<int> tripple_bets8;
    public List<int> tripple_bets9;
    public string tripple_win_position;
    public List<int> tripple_history_singles;
    public List<int> tripple_history_doubles;
    public List<int> tripple_history_tripples;
    public List<string> tripple_history_draw_time;
    public List<int> tripple_doublebonus;
    public string tripple_nextdraw;
}

[System.Serializable]
public class LuckyCardsStartGameData
{
    public bool status;
    public int gameplay;
    public string usercredit;
    public int gametime;
    public List<string> jeetojokerhistory;
    public int jeetojokerwinposition;
    public string jeetojokernextdraw;
    public List<int> jeetojokerbonus_history;
    public List<string> jeetojokertime_history;
}

[System.Serializable]
public class JeethoRaftherStartGameData
{
    public bool status;
    public int gameplay;
    public string usercredit;
    public int gametime;
    public List<string> horserace_history;
    public int horserace_win_position;
    public string horserace_next_draw;
    public List<int> horserace_history_bonus;
    public List<string> horserace_history_time;
    public IList<int> horserace_bet;
}

[System.Serializable]
public class JeethoRaftherDrawBetDatas
{
    public bool status;
    public string horserace_next_draw;
    public int gameplay;
    public string win_number;
    public int gametime;
    public List<string> horserace_history;
    public string usercredit;
    public int horserace_bonus;
    public int horserace_winAmount;

    public List<int> horserace_history_bonus;
    public List<string> horserace_history_time;
    public List<Horserace_position> horserace_position;
    }
public class Horserace_position
{
    public int Pos0;
    public int Pos1;
    public int Pos2;
    public int Pos3;
    public int Pos4;

}
[System.Serializable]
public class TrippleChanceDrawBetData
{
    public bool status;
    public string tripple_nextdraw;
    public int tripple_gameplay;
    public string tripple_winnumber;
    public int tripple_doublebonus;
    public int tripple_winamount;
    public int tripple_gametime;
    public List<int> tripple_history_singles;
    public List<int> tripple_history_doubles;
    public List<int> tripple_history_tripples;
    public List<string> tripple_history_draw_time;
    public string usercredit;
    public List<int> tripple_doublebonus_history;
}


[System.Serializable]
public class FiftyTwoCardsStartGameData
{
    public bool status;
    public int gameplay;
    public string usercredit;
    public int gametime;
    public List<string> card52_history;
    public int card52_winposition;
    public string card52_nextdraw;
    public List<int> card52_bonus_history;
    public List<string> card52_time_history;
}

[System.Serializable]
public class LuckyCardsDrawBetDatas
{
    public bool status;
    public string jeetojokernext_draw;
    public int gameplay;
    public string win_number;
    public int gametime;
    public List<string> jeetojokerhistory;
    public string usercredit;
    public int gamebonus;
    public int win_amount;
    public List<int> jeetojokerhistory_bonus;
    public List<string> jeetojokerhistory_time;
}

[System.Serializable]

public class LuckyCardsGameSummary
{
    public bool status;
    public int msg;
    public List<int> game_play;
    public List<string> game_id;
    public List<string> play;
    public List<string> win;
    public List<string> claim_point;
    public List<string> ticket_status;
    public List<string> draw_time;
    public List<int> result;
    public List<string> ticket_time;
    public List<object> cancel_time;
    public List<string> double_bonus;
    public List<int> start_point;
    public List<int> end_point;
    public List<string> play_status;
    public List<int> end;
    public int total_summary_act;

    public int total_summary;
    public int current_page;
    public int total_pages;
}

[System.Serializable]
public class LuckyCardsPlayBet
{
    public bool status;
    public int gametime;
    public string unique_id;
    public int betvalue;
    public List<int> playdetails;
    public string totalbet;
    public int gameplay;
    public string bettime;
    public string drawtime;
}

[System.Serializable]

public class LuckyCardsClaimBet
{
    public double credit;
    public object blocked;
    public string unique_id;
    public string total_won;
    public string total_bet;
    public int bet_gameplay;
    public string draw_time;
    public bool status;
    public int spin_time;
    public string winNumber;
    public int game_play;
}

[System.Serializable]
public class JeethoRaftherPlayBet
{
    public bool status;
    public int gametime;
    public string unique_id;
    public int betvalue;
    public List<int> playdetails;
    public string totalbet;
    public int gameplay;
    public string bettime;
    public string drawtime;
}

[System.Serializable]
public class JeethoRaftherClaimBet
{
    public double credit;
    public object blocked;
    public string unique_id;
    public string total_won;
    public string total_bet;
    public int bet_gameplay;
    public string draw_time;
    public bool status;
    public int spin_time;
    public string winNumber;
    public int game_play;
}

[System.Serializable]
public class JeethoRaftherGameSummary
{
    public bool status;
    public int msg;
    public List<int> game_play;
    public List<string> game_id;
    public List<string> play;
    public List<string> win;
    public List<string> claim_point;
    public List<string> ticket_status;
    public List<string> draw_time;
    public List<int> result;
    public List<string> ticket_time;
    public List<object> cancel_time;
    public List<string> double_bonus;
    public List<int> start_point;
    public List<int> end_point;
    public List<string> play_status;
    public List<int> end;
    public int total_summary_act;

    public int total_summary;
    public int current_page;
    public int total_pages;
}

[System.Serializable]
public class FunTargetStartGameData
{
    public bool status;
    public int gameplay;
    public string usercredit;
    public int gametime;
    public List<string> funtargethistory;
    public int funtargetwinposition;
    public string funtargetnextdraw;
    public List<int> funtargetbonus_history;
    public List<string> funtargettime_history;
}

