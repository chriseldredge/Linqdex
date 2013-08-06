using Lucene.Net.Index;
using Lucene.Net.Linq.Mapping;
using Lucene.Net.Search;

namespace Linqdex
{
    internal class Key : IDocumentKey
    {
        private const string keyField = "__key";
        private readonly string _key;
        public Key(string key)
        {
            _key = key;
        }


        public bool Equals(IDocumentKey other)
        {
            var otherPie = other as Key;
            if (otherPie != null)
            {
                return otherPie._key == this._key;
            }
            return false;
        }


        public Query ToQuery()
        {
            return new TermQuery(new Term(keyField, this._key));
        }

        public bool Empty { get { return false; } }

        

        public object this[string property]
        {
            get
            { 
                if (property == null)
                {
                    throw new ArgumentNullException("property");
                }

                if (property == keyField)
                {
                    return _key;
                }

                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<string> Properties
        {
            get { return new[] { keyField }; }
        }
    }
}
