using DP_music.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_music.staticData
{
    public class StaticData
    {
        public List<Genre> getStaticGenre()
        {
            List<Genre> genre = new List<Genre>();
            genre.Add(new Genre("1", "rock", "Rock music is a broad genre of popular music that originated " +
                "as \"rock and roll\" in the United States in the late 1940s and early 1950s, developing into " +
                "a range of different styles in the mid-1960s and later, particularly in the United States and " +
                "the United Kingdom.", @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\wwwroot\Images\1.png"));
            genre.Add(new Genre("2", "pop", "The terms popular music and pop music are often used interchangeably, " +
                "although the former describes all music that is popular and includes many disparate styles. During " +
                "the 1950s and 1960s, pop music encompassed rock and roll and the youth-oriented styles it influenced.",
                @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\wwwroot\Images\2.png"));
            genre.Add(new Genre("1", "classic", "Classical music is art music produced or rooted in the traditions of Western " +
                "culture, including both liturgical (religious) and secular music. Historically, the term 'classical music' " +
                "refers specifically to the musical period from 1750 to 1820 (the Classical period). In a more general sense " +
                "classical music refers to Western musical traditions considered to be apart from or a refinement of western " +
                "folk music traditions and encompasses the broad span of time from before the 6th century AD to the present day, " +
                "which includes the Classical period and various other periods.",
                @"D:\ВТК\4 курс\#Диплом\Проекти\DP_music\API\API\wwwroot\Images\3.png"));
            return genre;
        }
    }
}
