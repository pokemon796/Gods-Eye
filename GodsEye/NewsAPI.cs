using System;
using System.Diagnostics;
using System.Collections;

using Foundation;

namespace GodsEye
{
    public class News
    {
        private String title;
        private String source;
        private String url;

        public News()
        {
        }

        public String Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public String Source
        {
            get { return this.source; }
            set { this.source = value; }
        }

        public String URL
        {
            get { return this.url; }
            set { this.url = value; }
        }
    }

    public class Domains
    {
        private ArrayList DomainsList;
        private String DomainsFile;

        public Domains()
        {
            this.DomainsList = new ArrayList();

            DomainsFile = NSBundle.MainBundle.PathForResource("Domains", "txt");
            NSData domainsData = NSData.FromFile(DomainsFile);
            String domains = NSString.FromData(domainsData, NSStringEncoding.UTF8);
            String[] domainsList = domains.Split(",");

            foreach (String domain in domainsList)
            {
                this.Add(domain);
            }

        }

        public void Add(String Domain)
        {
            this.DomainsList.Add(Domain);
        }

        public void Remove(int Index)
        {
            this.DomainsList.RemoveAt(Index);
        }

        public int IndexOf(String Domain)
        {
            return DomainsList.IndexOf(Domain);
        }

        public bool Contains(String Domain)
        {
            return DomainsList.Contains(Domain);
        }

        public void Move(String Domain, int Location)
        {
            this.Remove(this.IndexOf(Domain));
            this.DomainsList.Insert(Location, Domain);
        }

        public ArrayList GetDomains()
        {
            ArrayList CompleteDomains = new ArrayList(this.DomainsList.Count);
            for (int i = 0; i < this.DomainsList.Count; i++)
            {
                String[] Domain = new String[2];
                Domain[0] = "http://www.google.com/s2/favicons?domain=" + this.DomainsList[i];
                Domain[1] = (String)this.DomainsList[i];

                CompleteDomains.Add(Domain);
            }

            return CompleteDomains;
        }

        public override String ToString()
        {
            String domains = "";

            for (int i = 0; i < DomainsList.Count; i++)
            {
                domains += (String)DomainsList[i];
                domains += i < DomainsList.Count - 1 ? "," : "";
            }

            return domains;
        }

        public void Save()
        {
            NSError SavingError = null;
            bool success = NSData.FromString(this.ToString()).Save(DomainsFile, false, out SavingError);
            if (success == false)
            {
                System.Console.WriteLine(SavingError);
            }
        }
    }

    public class NewsAPI
    {
        public static NewsAPI Main;

        private Domains NewsDomains;
        private ArrayList Stories;

        private int currentStory;

        public NewsAPI()
        {
            // This program uses the NewsAPI network. The code for connecting
            // with the API, using the APIKey, and pulling the data was compiled
            // into the NewsData binary located in the resources folder. This
            // was for both safety precautions and simplicity. The language that
            // the API puller was built with was Apple's Swift.

            NewsDomains = new Domains();
            this.currentStory = 0;
        }

        public Domains DomainsList
        {
            get { return this.NewsDomains; }
        }

        public News[] GetStories()
        {
            News[] NewsStories = new News[this.Stories.Count];

            for (int i = 0; i < NewsStories.Length; i++)
            {
                NewsStories[i] = (News)this.Stories[i];
            }

            return NewsStories;
        }

        public void FetchData(Action Completion)
        {
            Process API = new Process();
            API.StartInfo.UseShellExecute = false;
            API.StartInfo.RedirectStandardOutput = true;
            API.StartInfo.FileName = NSBundle.MainBundle.PathForResource("NewsData", "");
            API.StartInfo.Arguments = NewsDomains.ToString();
            API.Start();
            string[] output = API.StandardOutput.ReadToEnd().Split("\n");
            API.WaitForExit();

            this.OrganizeData(output,Completion);
        }

        private void OrganizeData(String[] Data, Action Completion)
        {
            Stories = new ArrayList((Data.Length / 3) + 1);
            int buffer = 1;
            int current = 0;
            for (int i = 0; i < Data.Length; i++)
            {
                if (buffer == 1)
                {
                    Stories.Add(new News());
                    ((News)Stories[current]).Title = Data[i];
                    buffer = 2;
                } else if (buffer == 2)
                {
                    ((News)Stories[current]).Source = Data[i];
                    buffer = 3;
                } else if (buffer == 3)
                {
                    ((News)Stories[current]).URL = Data[i];
                    current += 1;
                    buffer = 1;
                }
            }

            Completion();
        }
    }
}
