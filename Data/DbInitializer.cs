using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(SacramentMeetingPlannerContext context)
        {
            if(context.Hymn.Any())
            {
                return; // DB has been seeded
            }

            var hymns = new Hymn[]
            {
                new Hymn { HymnNumber = 1, HymnTitle = "The Morning Breaks", HymnType = "Restoration" },
                new Hymn { HymnNumber = 2, HymnTitle = "The Spirit of God", HymnType = "Restoration" },
                new Hymn { HymnNumber = 3, HymnTitle = "Now Let Us Rejoice", HymnType = "Restoration" },
                new Hymn { HymnNumber = 4, HymnTitle = "Truth Eternal", HymnType = "Restoration" },
                new Hymn { HymnNumber = 5, HymnTitle = "High on the Mountain Top", HymnType = "Restoration" },
                new Hymn { HymnNumber = 6, HymnTitle = "Redeemer of Israel", HymnType = "Restoration" },
                new Hymn { HymnNumber = 7, HymnTitle = "Israel, Israel, God Is Calling", HymnType = "Restoration" },
                new Hymn { HymnNumber = 8, HymnTitle = "Awake and Arise", HymnType = "Restoration" },
                new Hymn { HymnNumber = 9, HymnTitle = "Come, Rejoice", HymnType = "Restoration" },
                new Hymn { HymnNumber = 10, HymnTitle = "Come, Sing to the Lord", HymnType = "Restoration" },
                new Hymn { HymnNumber = 11, HymnTitle = "What Was Witnessed in the Heavens?", HymnType = "Restoration" },
                new Hymn { HymnNumber = 12, HymnTitle = @"'Twas Witnessed in the Morning Sky", HymnType = "Restoration" },
                new Hymn { HymnNumber = 13, HymnTitle = "An Angel from on High", HymnType = "Restoration" },
                new Hymn { HymnNumber = 14, HymnTitle = "Sweet Is the Peace the Gospel Brings", HymnType = "Restoration" },
                new Hymn { HymnNumber = 15, HymnTitle = "I Saw a Mighty Angel Fly", HymnType = "Restoration" },
                new Hymn { HymnNumber = 16, HymnTitle = "What Glorious Scenes Mine Eyes Behold", HymnType = "Restoration" },
                new Hymn { HymnNumber = 17, HymnTitle = "Awake, Ye Saits of God, Awake!", HymnType = "Restoration" },
                new Hymn { HymnNumber = 18, HymnTitle = "The Voice of God Again Is Heard", HymnType = "Restoration" },
                new Hymn { HymnNumber = 19, HymnTitle = "We Thank Thee, O God, For a Prophet", HymnType = "Restoration" },
                new Hymn { HymnNumber = 20, HymnTitle = "God of Power, God of Right", HymnType = "Restoration" },
                new Hymn { HymnNumber = 21, HymnTitle = "Come, Listen to a Prophet's Voice", HymnType = "Restoration" },
                new Hymn { HymnNumber = 22, HymnTitle = "We Listen to a Prophet's Voice", HymnType = "Restoration" },
                new Hymn { HymnNumber = 23, HymnTitle = "We Ever Pray for Thee", HymnType = "Restoration" },
                new Hymn { HymnNumber = 24, HymnTitle = "God Bless Our Prophet Dear", HymnType = "Restoration" },
                new Hymn { HymnNumber = 25, HymnTitle = "Now We'll Sing with One Accord", HymnType = "Restoration" },
                new Hymn { HymnNumber = 26, HymnTitle = "Joseph Smith's First Prayer", HymnType = "Restoration" },
                new Hymn { HymnNumber = 27, HymnTitle = "Praise to the Man", HymnType = "Restoration" },
                new Hymn { HymnNumber = 28, HymnTitle = "Saints, Behold How Great Jehovah", HymnType = "Restoration" },
                new Hymn { HymnNumber = 29, HymnTitle = "A Poor Wayfaring Man of Grief", HymnType = "Restoration" },
                new Hymn { HymnNumber = 30, HymnTitle = "Come, Come, Ye Saints", HymnType = "Restoration" },
                new Hymn { HymnNumber = 31, HymnTitle = "O God, Our Help in Ages Past", HymnType = "Restoration" },
                new Hymn { HymnNumber = 32, HymnTitle = "The Happy Day at Last Has Come", HymnType = "Restoration" },
                new Hymn { HymnNumber = 33, HymnTitle = "Our Mountain Home So Dear", HymnType = "Restoration" },
                new Hymn { HymnNumber = 34, HymnTitle = "O Ye Mountains High", HymnType = "Restoration" },
                new Hymn { HymnNumber = 35, HymnTitle = "For the Streangth of the Hills", HymnType = "Restoration" },
                new Hymn { HymnNumber = 36, HymnTitle = "They, the Builders of the Nation", HymnType = "Restoration" },
                new Hymn { HymnNumber = 37, HymnTitle = "The Wintry Day, Descending to its Close", HymnType = "Restoration" },
                new Hymn { HymnNumber = 38, HymnTitle = "Come, All Ye Saints of Zion", HymnType = "Restoration" },
                new Hymn { HymnNumber = 39, HymnTitle = "O Saints of Zion", HymnType = "Restoration" },
                new Hymn { HymnNumber = 40, HymnTitle = "Arise, O Glorious Zion", HymnType = "Restoration" },
                new Hymn { HymnNumber = 41, HymnTitle = "Let Zion in Her Beauty Rise", HymnType = "Restoration" },
                new Hymn { HymnNumber = 42, HymnTitle = "Hail to the Brightness of Zion's Glad Morning!", HymnType = "Restoration" },
                new Hymn { HymnNumber = 43, HymnTitle = "Zion Stands with Hills Surrounded", HymnType = "Restoration" },
                new Hymn { HymnNumber = 44, HymnTitle = "Beautiful Zion, Built Above", HymnType = "Restoration" },
                new Hymn { HymnNumber = 45, HymnTitle = "Lead Me into Life Eternal", HymnType = "Restoration" },
                new Hymn { HymnNumber = 46, HymnTitle = "Glorious THings of Thee Are Spoken", HymnType = "Restoration" },
                new Hymn { HymnNumber = 47, HymnTitle = "We Will Sing of Zion", HymnType = "Restoration" },
                new Hymn { HymnNumber = 48, HymnTitle = "Glorious Things Are Sung of Zion", HymnType = "Restoration" },
                new Hymn { HymnNumber = 49, HymnTitle = "Adam-Ondi-Ahman", HymnType = "Restoration" },
                new Hymn { HymnNumber = 50, HymnTitle = "Come, THou Glorious Day of Promise", HymnType = "Restoration" },
            };

            foreach(Hymn h in hymns)
            {
                context.Hymn.Add(h);
            }
            context.SaveChanges();
        }
    }
}
