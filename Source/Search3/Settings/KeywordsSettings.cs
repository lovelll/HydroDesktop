using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Search3.Keywords;

namespace Search3.Settings
{
    public class KeywordsSettings
    {
        private readonly SearchSettings _parent;

        public KeywordsSettings(SearchSettings parent)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            _parent = parent;
        }

        /// <summary>
        /// Fires when Keywords/OntologyTree/Synonyms changed
        /// </summary>
        public event EventHandler KeywordsChanged;

        private IEnumerable<string> _selectedKeywords;
        public IEnumerable<string> SelectedKeywords
        {
            get { return _selectedKeywords ?? (_selectedKeywords = new string[]{}); }
            set
            {
                _selectedKeywords = value;
            }
        }

        private IList<string> _keywords;
        public IList<string> Keywords
        {
            get
            {
                if (_keywords == null)
                {
                    UpdateKeywordsAndOntology();
                }
                Debug.Assert(_keywords != null);
                return _keywords;
            }
            private set
            {
                _keywords = value;
            }
        }

        private OntologyTree _ontologyTree;
        public OntologyTree OntologyTree
        {
            get
            {
                if (_ontologyTree == null)
                {
                    UpdateKeywordsAndOntology();
                }
                Debug.Assert(_ontologyTree != null);
                return _ontologyTree;
            }
            private set { _ontologyTree = value; }
        }

        private List<OntologyPath> Synonyms { get; set; }

        /// <summary>
        /// Returns synonym for keyword.
        /// </summary>
        /// <param name="keyword">Keyword to find synonym.</param>
        /// <returns>Synonym for keyword, or keyword, if synonym not found.</returns>
        public string FindSynonym(string keyword)
        {
            var synonyms = Synonyms;
            if (synonyms != null)
            {
                foreach (var ontoPath in synonyms)
                {
                    if (string.Equals(ontoPath.SearchableKeyword, keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        keyword = ontoPath.ConceptName;
                        break;
                    }
                }
            }

            return keyword;
        }
    

        public void UpdateKeywordsAndOntology(CatalogSettings catalogSettings = null)
        {
            var keywordsData = new KeywordsList().GetKeywordsListData(catalogSettings ?? _parent.CatalogSettings);
            // Replace Hydroshpere with All
            keywordsData.Keywords.Remove("Hydrosphere");
            keywordsData.Keywords.Add("All");
            if (keywordsData.OntoloyTree.Nodes.Count > 0)
            {
                keywordsData.OntoloyTree.Nodes[0].Text = "All";
            }
            if (_selectedKeywords == null)
            {
                _selectedKeywords = new[] {"All"};
            }
            //

            Keywords = keywordsData.Keywords.ToList();
            OntologyTree = keywordsData.OntoloyTree;
            Synonyms = keywordsData.Synonyms;

            RaiseKeywordsChanged();
        }

        /// <summary>
        /// Create deep copy of current instance.
        /// </summary>
        /// <returns>Deep copy.</returns>
        public KeywordsSettings Copy()
        {
            var result = new KeywordsSettings(_parent);
            result.Copy(this);
            return result;
        }

        /// <summary>
        /// Create deep from source into current instance.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/>must be not null.</exception>
        public void Copy(KeywordsSettings source)
        {
            if (source == null) throw new ArgumentNullException("source");

            var selectedKeywords = new List<string>(source.SelectedKeywords.Count());
            selectedKeywords.AddRange(source.SelectedKeywords.Select(s => s));
            SelectedKeywords = selectedKeywords;

            Keywords = source.Keywords;
            OntologyTree = source.OntologyTree;
            Synonyms = source.Synonyms;

            RaiseKeywordsChanged();
        }

        #region Private methods

        private void RaiseKeywordsChanged()
        {
            var handler = KeywordsChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}