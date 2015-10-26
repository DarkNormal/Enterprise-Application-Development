using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSampleExam4
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        SoccerTeam team = new SoccerTeam("Manchester", Gender.Male, 36);
    //        SoccerPlayer zlatan = new SoccerPlayer("Zlatan Ibra", new DateTime(1978, 4, 21), Gender.Male, SoccerPosition.Striker);
    //        team.AddToTeam(zlatan);
    //        foreach(SoccerPlayer s in team)
    //        {
    //            Console.WriteLine(s.ToString());
    //        }
    //        Console.ReadLine();
    //    }
    //}
    public enum Gender
    {
        Male, Female
    }
    public enum SoccerPosition {
    
        Goalkeeper, Defender, Midfielder, Striker
    }

    public abstract class SportsPlayer
    {
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public Gender Sex { get; set; }
        public SportsPlayer() { }
        public SportsPlayer(string name, DateTime dob, Gender sex)
        {
            Name = name;
            Dob = dob;
            Sex = sex;
        }
        public override string ToString()
        {
            int age = GetAge(Dob);
            string playerDetails = "Name: " + Name + "\nAge: " + age + "\nGender: " + Sex;
            return playerDetails;
        }
        public int GetAge(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;
            if(DateTime.Now < dob.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }

    public class SoccerPlayer : SportsPlayer
    {
        public SoccerPosition Position { get; set; }
        public SoccerPlayer()
        {
            Name = "";
            Dob = DateTime.Now;
            Sex = Gender.Male;
            Position = SoccerPosition.Defender;
        }
        public SoccerPlayer(string name, DateTime dob, Gender sex, SoccerPosition position) : base(name, dob, sex)
        {
            Position = position;
        }
        public override string ToString()
        {

            return base.ToString() + "\nPosition: " + Position;
        }
    }
    public class SoccerTeam : IEnumerable
    {
        public const int NoLimit = Int32.MaxValue;
        private int ageLimit;
        public string TeamName { get; set; }
        public Gender TeamGender { get; set; }
        public int AgeLimit {
            get {
                return ageLimit;
            }
            set {
                if(value >= 5)
                {
                    ageLimit = value;
                }
                else
                {
                    throw new ArgumentException("Age limit must be greater than 5");
                }
            }
        }
        private List<SoccerPlayer> team;
        public List<SoccerPlayer> Team
        {
            get { return new List<SoccerPlayer>(team); }
        }

        public SoccerTeam(string teamName, Gender teamGender, int ageLimit)
        {
            TeamName = teamName;
            TeamGender = teamGender;
            AgeLimit = ageLimit;
            team = new List<SoccerPlayer>();
        }

        public IEnumerator GetEnumerator()
        {
           foreach(SoccerPlayer s in Team)
            {
                yield return s;
            }
        }
        public SoccerPlayer this[string name]
        {
            get
            {
                SoccerPlayer p= null;
                bool foundPlayer = false;
                for (int i = 0; i < Team.Count; i++)
                {
                    if (Team[i].Name.ToLower().Equals(name.ToLower())){
                        p = Team[i];
                        foundPlayer = true;
                    }
                }
                if (foundPlayer)
                {
                    return p;
                }
                else
                {
                    throw new ArgumentException("No matching player found");
                }
            }
        }
        public void AddToTeam(SoccerPlayer newPlayer)
        {
            if(team == null)
            {
                team.Add(newPlayer);
            }
            else
            {
                if (team.Contains(newPlayer))
                {
                    throw new ArgumentException("Player is already part of the team");
                }
                else
                {
                    if(newPlayer.Sex == TeamGender)
                    {
                        if(newPlayer.GetAge(newPlayer.Dob) <= AgeLimit)
                        {
                            team.Add(newPlayer);
                        }
                        else { throw new ArgumentException("Player is too old"); }
                    }
                    else { throw new ArgumentException("Team cannot be mixed-gender"); }
                }
            }
        }
    }
}
