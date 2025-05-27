using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE

        // HashSet<string> results = new HashSet<string>();

        List<string> tempResults = new List<string>();
        HashSet<string> tempSet = new HashSet<string>(words);
        HashSet<string> goneSet = new HashSet<string>();
        // add each letter of each string to the set. If another equal letter is added, check

        int counter = -1;
        foreach (var word in words)
        {
            var firstLetter = word[0];
            var secondLetter = word[1];
            string inverse = $"{word[1]}{word[0]}";
            string tempSt;
            if (tempSet.Contains(inverse))
            {
                if (!goneSet.Contains(inverse) && !goneSet.Contains(word) && firstLetter != secondLetter)
                {
                    counter++;
                    tempSt = $"{inverse} & {word}";
                    tempResults.Add(tempSt);
                }
                goneSet.Add(inverse);
                goneSet.Add(word);
            } 
            tempSet.Add(word);


        }

        String[] results = tempResults.ToArray();           


            


        
        return results;
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degreeName = fields[3];

            if (degrees.ContainsKey(degreeName))
            {
                degrees[degreeName]++;
            }
            else
            {
                degrees.Add(degreeName, 1);
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        char b;
        char c;
        int counter = 0;
        int firstwordDupliacte = 0;
        int secondWordDuplicate = 0;
        
        // var firstWord = new Dictionary<char, char>();
        var firstWord = new Dictionary<int, char>();
        var secondWord = new Dictionary<int, char>();
        var firstduplicates = new Dictionary<int, char>();
        var secondduplicates = new Dictionary<int, char>();

        word1 = word1.Replace(" ", "");
        word2 = word2.Replace(" ", "");


        if (word1.Length == word2.Length)
        {



            foreach (char a in word1)
            {
                if (a != ' ')
                {

                    b = char.ToLower(a);
                    c = char.ToLower(word2[counter]);

                    if (firstWord.Values.Contains(b) && !firstduplicates.Values.Contains(b))
                    {
                        firstwordDupliacte++;
                        firstduplicates.Add(firstwordDupliacte, b);
                    }

                    if (secondWord.Values.Contains(c) && !secondduplicates.Values.Contains(c))
                    {
                        secondWordDuplicate++;
                        secondduplicates.Add(secondWordDuplicate, c);
                    }




                    firstWord.Add(counter, b);
                    secondWord.Add(counter, c);
                    counter++;
                }

            }

            foreach (char value in firstWord.Values)
            {
                if (!secondWord.Values.Contains(value))
                {
                    return false;
                }
            }


            foreach (char val in firstduplicates.Values)
            {
                int count1 = firstWord.Values.Count(v => v == val);
                int count2 = secondWord.Values.Count(v => v == val);

                if (count1 != count2)
                {
                    return false;
                }

            }

            return true;
        }

          









            return false;
        }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        List<string> tempstr = new List<string>();
        string s = "";
        long time;
        bool isToday;
        
        foreach (var feature in featureCollection.features)
        {
            time = feature.properties.time;
            DateTime dateTimeUtc = DateTimeOffset.FromUnixTimeMilliseconds(time).UtcDateTime;

            DateTime DateTimeLocal = dateTimeUtc.ToLocalTime();

            DateTime today = DateTime.Now.Date;

            isToday = DateTimeLocal.Date == today;
            if (isToday)
            {
            s = $"{feature.properties.place} - Mag {feature.properties.mag}";
            tempstr.Add(s);
                
            }
        }

        string[] result = tempstr.ToArray();
        

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return result;
    }
}