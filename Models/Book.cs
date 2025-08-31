namespace thing.Models
	{
	    public class Book
	    {
	        public string name;
	        public string author;
	 
	        public int publicationDate;

            public string genere;
			public bool takenornot;

		public Book(string name, string author, int publicationDate, string genere, bool takenornot)
		{
			this.name = name;
			this.author = author;
			this.publicationDate = publicationDate;
			this.genere = genere;
			this.takenornot = takenornot;

		}
	 
	        public override string ToString()
	        {
	            return this.name + ", " + this.author + ", " + this.publicationDate + ", " + this.genere + ", " + this.takenornot;
	        }
	    }
	}