using System;

namespace TweetsTokenizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string example1 = "Dr. Stephaun Wallace (@imstephaunelite) has spent the last year helping make COVID-19 vaccines work for everybody.Stephaun and his colleagues at @FredHutch are working to reach the people who are usually left behind.";
            // expected 2 mentions,  @imstephaunelite, @FredHutch, 0 hashtags

            string example2 = "It's #WorldTBDay Even as we battle #COVID19, we must not ease up the fight against #Tuberculosis, which remains the Earth's deadliest infectious killer. Each day this preventable & curable disease causes: 4000 deaths 28000 new casesLet's #EndTB";
            // expected 0 mentions, 4 hashtags, #WorldTBDay, #COVID19, #Tuberculosis, #EndTB

            string example3 = "Thank you @SalKha_nAcademy for a great conversation about climate change and thanks to @BookPeople and @BlueWillowBooks for hosting the event.";
            // expected 2 mentions,  @SalKha_nAcademy, @BookPeople, @BlueWillowBooks, 0 hashtags

            string example4 = "As families have been forced to play dual role of parent and teacher due to #COVID19, @khanacademy founder @salkhanacademy tells @_margbrennan in a new #FacingForwardPod there's no substitute for an amazing in-person teacher.";
            // expected 3 mentions,  @khanacademy, @salkhanacademy, @_margbrennan, 2 hashtags, #COVID19, #FacingForwardPod

            string example5 = "Always enjoy speaking to Squawk Box team. Although sometimes hard to not look like I was in bed 2 minutes earlier when it is at 5am pt :)";
            // expected 0 mentions, 0 hashtags

            tweetsTokenizer(example1);

            Console.WriteLine("");

            tweetsTokenizer(example2);

            Console.WriteLine("");

            tweetsTokenizer(example3);

            Console.WriteLine("");

            tweetsTokenizer(example4);

            Console.WriteLine("");

            tweetsTokenizer(example5);
        }

        static void tweetsTokenizer(string source)
        {
            int hashtags = 0;
            int mentions = 0;

            for (int i = 0; i < source.Length; i++)
            {

                if (source[i] == '#' || source[i] == '@')
                {
                    string token = "";

                    do
                    {
                        token += source[i];
                        i++;
                    }
                    while (i < source.Length && (Char.IsLetterOrDigit(source[i]) || source[i] == '_'));

                    if (token[0] == '@' && token.Length < 17 && token.Length > 6)
                    {
                        Console.WriteLine(token);
                        mentions++;
                    }
                    else
                    {
                        hashtags++;
                        Console.WriteLine(token);
                    }
                }

            }

            Console.WriteLine("hashtags: " + hashtags);
            Console.WriteLine("mentions: " + mentions);

        }
    }
}
