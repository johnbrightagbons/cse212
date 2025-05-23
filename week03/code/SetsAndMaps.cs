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
        // TODO Problem 1 - 
        // Use a HashSet for 0(1) lookups
        var wordSet = new HashSet<string>(words); // O(n)
        var result = new List<string>(); // O(n)
        var usedWord = new HashSet<string>(); // Helps avoid duplicates

        // Loop through each word
        foreach (var word in words)
        {
            // Skip words that have already been used (aa)
            if (word[0] == word[1])
                continue;

            // Create the reverse word
            var reversedWord = new string(new[] { word[1], word[0] });

            // Check if the reversed word is in the set and has not been used
            if (wordSet.Contains(reversedWord) && !usedWord.Contains(word) && !usedWord.Contains(reversedWord))
            {
                result.Add($"{word} & {reversedWord}"); // Add the pair to the result
                usedWord.Add(word); // Mark the word as used,
                usedWord.Add(reversedWord); // Mark the reversed word as used
            }
        }
        return result.ToArray(); // Convert the list to an array and return
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
            // TODO Problem 2 
            // The degree is in the 4th column (index 3)
            var degree = fields[3].Trim(); // Trim whitespace

            // Check if degree is in the dictionary and increase the count
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++; // Increment the count
            }
            else
            {
                degrees[degree] = 1; // Add new degree with count 1
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
        // TODO Problem 3 -
        // Remove spaces and convert to lower case
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // Check if lengths are different
        if (word1.Length != word2.Length)
            return false;

        // Create a dictionary to count letters
        var letterCounts = new Dictionary<char, int>();
        // Count letters in word1
        foreach (var letter in word1)
        {
            if (letterCounts.ContainsKey(letter)) // Check if letter is already in the dictionary

                letterCounts[letter]++; // Add to the count

            else

                letterCounts[letter] = 1; // Add new letter with count 1

        }

        // Subract the frequent letters in word2
        foreach (var letter in word2)
        {
            if (!letterCounts.ContainsKey(letter)) // If letter is not in the dictionary
                return false; // Letters are not anagrams

            letterCounts[letter]--; // Decrease the count
            if (letterCounts[letter] < 0) // If count goes below 0
                return false; // Letters are not anagrams
        }
        return true; // All letters matched
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

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // Check if featureCollection is null
        if (featureCollection == null || featureCollection.Features == null)
            return Array.Empty<string>(); // Return an empty array if null

        // Create a list to store the earthquake descriptions
        var result = new List<string>();

        // Loop through each feature in the feature collection
        foreach (var feature in featureCollection.Features)
        {
            // Check if properies are null
            if (feature?.Properties?.place != null && feature.Properties.Mag != null)
            {
                result.Add($"Magnitude: {feature.Properties.Mag}, Place: {feature.Properties.place}"); // Add the description to the list
            }
        }
        return result.ToArray(); // Convert the list to an array and retur
    }
}

