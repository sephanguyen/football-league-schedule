using Repositories.Enum;

namespace FootBallLeagueSchedule.Helpers
{
    public class ParserForeign
    {
        public static StatusForeign Parse(bool value) {
            switch(value) {
                case true:
                    return StatusForeign.Foreign;
                default:
                    return StatusForeign.Native;
            }
        }
    }
}