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
                new Hymn { HymnNumber = 51, HymnTitle = "Sons of Michal, He Approaches", HymnType = "Restoration" },
                new Hymn { HymnNumber = 52, HymnTitle = "The Day Dawn Is Breaking", HymnType = "Restoration" },
                new Hymn { HymnNumber = 53, HymnTitle = "Let Earth's Inhabitants Rejoice", HymnType = "Restoration" },
                new Hymn { HymnNumber = 54, HymnTitle = "Behold, the Mountain of the Lord", HymnType = "Restoration" },
                new Hymn { HymnNumber = 55, HymnTitle = "Lo, the Mighty God Appearing!", HymnType = "Restoration" },
                new Hymn { HymnNumber = 56, HymnTitle = "Softly Beams the Sacred Dawning", HymnType = "Restoration" },
                new Hymn { HymnNumber = 57, HymnTitle = "We're Not Ashamed to Own Our Lord", HymnType = "Restoration" },
                new Hymn { HymnNumber = 58, HymnTitle = "Come, Ye Children of the Lord", HymnType = "Restoration" },
                new Hymn { HymnNumber = 59, HymnTitle = "Come, O Thou King of Kings", HymnType = "Restoration" },
                new Hymn { HymnNumber = 60, HymnTitle = "Battle Hymn of the Republic", HymnType = "Restoration" },
                new Hymn { HymnNumber = 61, HymnTitle = "Raise Your Voices to the Lord", HymnType = "Restoration" },
                new Hymn { HymnNumber = 62, HymnTitle = "All Creatures of Our God and King", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 63, HymnTitle = "Great King of Heaven", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 64, HymnTitle = "On This Day of Joy and Gladness", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 65, HymnTitle = "Come, All Ye Saints Who Dwell on Earth", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 66, HymnTitle = "Rejoice, the Lord is King!", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 67, HymnTitle = "Glory to God on High", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 68, HymnTitle = "A mighty Fortress Is Our God", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 69, HymnTitle = "All Glory, Laud, and Honor", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 70, HymnTitle = "Sing Praise to Him", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 71, HymnTitle = "With Songs of Praise", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 72, HymnTitle = "Praise to the Lord, the Almighty", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 73, HymnTitle = "Praise the Lord with Heart and Voice", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 74, HymnTitle = "Praise Ye the Lord", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 75, HymnTitle = "In Hymns of Praise", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 76, HymnTitle = "God of Our Fathers, We Come unto Thee", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 77, HymnTitle = "Great Is the Lord", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 78, HymnTitle = "God of Our Fathers, Whose Almighty Hand", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 79, HymnTitle = "With All the Power of Heart and Tongue", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 80, HymnTitle = "God of Our Fathers, Known of Old", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 81, HymnTitle = "Press Forward, Saints", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 82, HymnTitle = "For All the Saints", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 83, HymnTitle = "Guide Us, O thou Great Jehovah", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 84, HymnTitle = "Faith of Our Fathers", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 85, HymnTitle = "How Firm a Foundation", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 86, HymnTitle = "How Great Thou Art", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 87, HymnTitle = "God Is Love", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 88, HymnTitle = "Great GOd, Attend WHile Zion Sings", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 89, HymnTitle = "The Lord Is My Light", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 90, HymnTitle = "From All THat Dwell below the Skies", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 91, HymnTitle = "Father, Thy Children to Thee Now Raise", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 92, HymnTitle = "For the Beauty of the Earth", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 93, HymnTitle = "Prayer of Thanksgiving", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 94, HymnTitle = "Come, Ye Thanksful People", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 95, HymnTitle = "Now Thank We All Our God", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 96, HymnTitle = "Dearest Children, God Is Near You", HymnType = "Praise and Thanksgiving" },
                new Hymn { HymnNumber = 97, HymnTitle = "Lead, Kindly Light", HymnType = "Prayer and Supplication" },
                new Hymn { HymnNumber = 98, HymnTitle = "I Need Thee Every Hour", HymnType = "Prayer and Supplication" },
                new Hymn { HymnNumber = 99, HymnTitle = "Nearer, Dear Savior, to Thee", HymnType = "Prayer and Supplication" },
                new Hymn { HymnNumber = 100, HymnTitle = "Nearer, My God, to Thee", HymnType = "Prayer and Supplication" },
            };

            foreach(Hymn h in hymns)
            {
                context.Hymn.Add(h);
            }
            context.SaveChanges();
        }
    }
}
