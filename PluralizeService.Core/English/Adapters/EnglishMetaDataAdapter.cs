using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PluralizationService.Adapters;
using PluralizationService.Core;
using PluralizationService.English.Providers;

namespace PluralizationService.English.Adapters
{
    /// <summary>
    /// This class is an english implementation of <see cref="IMetaDataAdapter"/>
    /// </summary>
    internal class EnglishMetaDataAdapter : DisposableObject, IMetaDataAdapter
    {
        // *******************************************************************
        // Fields.
        // *******************************************************************

        #region Fields

        private BidirectionalDictionary<string, string> _userDictionary;

        private StringBidirectionalDictionary _irregularPluralsPluralizationService;

        private StringBidirectionalDictionary _assimilatedClassicalInflectionPluralizationService;

        private StringBidirectionalDictionary _oSuffixPluralizationService;

        private StringBidirectionalDictionary _classicalInflectionPluralizationService;

        private StringBidirectionalDictionary _irregularVerbPluralizationService;

        private StringBidirectionalDictionary _wordsEndingWithSePluralizationService;

        private StringBidirectionalDictionary _wordsEndingWithSisPluralizationService;

        private StringBidirectionalDictionary _wordsEndingWithSusPluralizationService;

        private StringBidirectionalDictionary _wordsEndingWithInxAnxYnxPluralizationService;

        private CultureInfo _culture;

        private List<string> _knownSingluarWords;

        private List<string> _knownPluralWords;

        private string[] _uninflectiveSuffixList = new string[] { "fish", "ois", "sheep", "deer", "pos", "itis", "ism" };

        private string[] _uninflectiveWordList = new string[] { "bison", "flounder", "pliers", "bream", "gallows", "proceedings", "breeches", "graffiti", "rabies", "britches", "headquarters", "salmon", "carp", "herpes", "scissors", "chassis", "high-jinks", "sea-bass", "clippers", "homework", "series", "cod", "innings", "shears", "contretemps", "jackanapes", "species", "corps", "mackerel", "swine", "debris", "measles", "trout", "diabetes", "mews", "tuna", "djinn", "mumps", "whiting", "eland", "news", "wildebeest", "elk", "pincers", "police", "hair", "ice", "chaos", "milk", "cotton", "pneumonoultramicroscopicsilicovolcanoconiosis", "information", "aircraft", "scabies", "traffic", "corn", "millet", "rice", "hay", "hemp", "tobacco", "cabbage", "okra", "broccoli", "asparagus", "lettuce", "beef", "pork", "venison", "mutton", "cattle", "offspring", "molasses", "shambles", "shingles" };

        private Dictionary<string, string> _irregularVerbList = new Dictionary<string, string>()
        {
            { "am", "are" },
            { "are", "are" },
            { "is", "are" },
            { "was", "were" },
            { "were", "were" },
            { "has", "have" },
            { "have", "have" }
        };

        private List<string> _pronounList = new List<string>()
        {
            "I",
            "we",
            "you",
            "he",
            "she",
            "they",
            "it",
            "me",
            "us",
            "him",
            "her",
            "them",
            "myself",
            "ourselves",
            "yourself",
            "himself",
            "herself",
            "itself",
            "oneself",
            "oneselves",
            "my",
            "our",
            "your",
            "his",
            "their",
            "its",
            "mine",
            "yours",
            "hers",
            "theirs",
            "this",
            "that",
            "these",
            "those",
            "all",
            "another",
            "any",
            "anybody",
            "anyone",
            "anything",
            "both",
            "each",
            "other",
            "either",
            "everyone",
            "everybody",
            "everything",
            "most",
            "much",
            "nothing",
            "nobody",
            "none",
            "one",
            "others",
            "some",
            "somebody",
            "someone",
            "something",
            "what",
            "whatever",
            "which",
            "whichever",
            "who",
            "whoever",
            "whom",
            "whomever",
            "whose"
        };

        private Dictionary<string, string> _irregularPluralsDictionary = new Dictionary<string, string>()
        {
            { "brother", "brothers" },
            { "child", "children" },
            { "cow", "cows" },
            { "ephemeris", "ephemerides" },
            { "genie", "genies" },
            { "money", "moneys" },
            { "mongoose", "mongooses" },
            { "mythos", "mythoi" },
            { "octopus", "octopuses" },
            { "ox", "oxen" },
            { "soliloquy", "soliloquies" },
            { "trilby", "trilbys" },
            { "crisis", "crises" },
            { "synopsis", "synopses" },
            { "rose", "roses" },
            { "gas", "gases" },
            { "bus", "buses" },
            { "axis", "axes" },
            { "memo", "memos" },
            { "casino", "casinos" },
            { "silo", "silos" },
            { "stereo", "stereos" },
            { "studio", "studios" },
            { "lens", "lenses" },
            { "alias", "aliases" },
            { "pie", "pies" },
            { "corpus", "corpora" },
            { "viscus", "viscera" },
            { "hippopotamus", "hippopotami" },
            { "trace", "traces" },
            { "person", "people" },
            { "chili", "chilies" },
            { "analysis", "analyses" },
            { "basis", "bases" },
            { "neurosis", "neuroses" },
            { "oasis", "oases" },
            { "synthesis", "syntheses" },
            { "thesis", "theses" },
            { "change", "changes" },
            { "lie", "lies" },
            { "calorie", "calories" },
            { "freebie", "freebies" },
            { "case", "cases" },
            { "house", "houses" },
            { "valve", "valves" },
            { "cloth", "clothes" },
            { "tie", "ties" },
            { "movie", "movies" },
            { "bonus", "bonuses" },
            { "specimen", "specimens" }
        };

        private Dictionary<string, string> _assimilatedClassicalInflectionDictionary = new Dictionary<string, string>()
        {
            { "alumna", "alumnae" },
            { "alga", "algae" },
            { "vertebra", "vertebrae" },
            { "codex", "codices" },
            { "murex", "murices" },
            { "silex", "silices" },
            { "aphelion", "aphelia" },
            { "hyperbaton", "hyperbata" },
            { "perihelion", "perihelia" },
            { "asyndeton", "asyndeta" },
            { "noumenon", "noumena" },
            { "phenomenon", "phenomena" },
            { "criterion", "criteria" },
            { "organon", "organa" },
            { "prolegomenon", "prolegomena" },
            { "agendum", "agenda" },
            { "datum", "data" },
            { "extremum", "extrema" },
            { "bacterium", "bacteria" },
            { "desideratum", "desiderata" },
            { "stratum", "strata" },
            { "candelabrum", "candelabra" },
            { "erratum", "errata" },
            { "ovum", "ova" },
            { "forum", "fora" },
            { "addendum", "addenda" },
            { "stadium", "stadia" },
            { "automaton", "automata" },
            { "polyhedron", "polyhedra" }
        };

        private Dictionary<string, string> _oSuffixDictionary = new Dictionary<string, string>()
        {
            { "albino", "albinos" },
            { "generalissimo", "generalissimos" },
            { "manifesto", "manifestos" },
            { "archipelago", "archipelagos" },
            { "ghetto", "ghettos" },
            { "medico", "medicos" },
            { "armadillo", "armadillos" },
            { "guano", "guanos" },
            { "octavo", "octavos" },
            { "commando", "commandos" },
            { "inferno", "infernos" },
            { "photo", "photos" },
            { "ditto", "dittos" },
            { "jumbo", "jumbos" },
            { "pro", "pros" },
            { "dynamo", "dynamos" },
            { "lingo", "lingos" },
            { "quarto", "quartos" },
            { "embryo", "embryos" },
            { "lumbago", "lumbagos" },
            { "rhino", "rhinos" },
            { "fiasco", "fiascos" },
            { "magneto", "magnetos" },
            { "stylo", "stylos" }
        };

        private Dictionary<string, string> _classicalInflectionDictionary = new Dictionary<string, string>()
        {
            { "stamen", "stamina" },
            { "foramen", "foramina" },
            { "lumen", "lumina" },
            { "anathema", "anathemata" },
            { "enema", "enemata" },
            { "oedema", "oedemata" },
            { "bema", "bemata" },
            { "enigma", "enigmata" },
            { "sarcoma", "sarcomata" },
            { "carcinoma", "carcinomata" },
            { "gumma", "gummata" },
            { "schema", "schemata" },
            { "charisma", "charismata" },
            { "lemma", "lemmata" },
            { "soma", "somata" },
            { "diploma", "diplomata" },
            { "lymphoma", "lymphomata" },
            { "stigma", "stigmata" },
            { "dogma", "dogmata" },
            { "magma", "magmata" },
            { "stoma", "stomata" },
            { "drama", "dramata" },
            { "melisma", "melismata" },
            { "trauma", "traumata" },
            { "edema", "edemata" },
            { "miasma", "miasmata" },
            { "abscissa", "abscissae" },
            { "formula", "formulae" },
            { "medusa", "medusae" },
            { "amoeba", "amoebae" },
            { "hydra", "hydrae" },
            { "nebula", "nebulae" },
            { "antenna", "antennae" },
            { "hyperbola", "hyperbolae" },
            { "nova", "novae" },
            { "aurora", "aurorae" },
            { "lacuna", "lacunae" },
            { "parabola", "parabolae" },
            { "apex", "apices" },
            { "latex", "latices" },
            { "vertex", "vertices" },
            { "cortex", "cortices" },
            { "pontifex", "pontifices" },
            { "vortex", "vortices" },
            { "index", "indices" },
            { "simplex", "simplices" },
            { "iris", "irides" },
            { "clitoris", "clitorides" },
            { "alto", "alti" },
            { "contralto", "contralti" },
            { "soprano", "soprani" },
            { "basso", "bassi" },
            { "crescendo", "crescendi" },
            { "tempo", "tempi" },
            { "canto", "canti" },
            { "solo", "soli" },
            { "aquarium", "aquaria" },
            { "interregnum", "interregna" },
            { "quantum", "quanta" },
            { "compendium", "compendia" },
            { "lustrum", "lustra" },
            { "rostrum", "rostra" },
            { "consortium", "consortia" },
            { "maximum", "maxima" },
            { "spectrum", "spectra" },
            { "cranium", "crania" },
            { "medium", "media" },
            { "speculum", "specula" },
            { "curriculum", "curricula" },
            { "memorandum", "memoranda" },
            { "stadium", "stadia" },
            { "dictum", "dicta" },
            { "millenium", "millenia" },
            { "trapezium", "trapezia" },
            { "emporium", "emporia" },
            { "minimum", "minima" },
            { "ultimatum", "ultimata" },
            { "enconium", "enconia" },
            { "momentum", "momenta" },
            { "vacuum", "vacua" },
            { "gymnasium", "gymnasia" },
            { "optimum", "optima" },
            { "velum", "vela" },
            { "honorarium", "honoraria" },
            { "phylum", "phyla" },
            { "focus", "foci" },
            { "nimbus", "nimbi" },
            { "succubus", "succubi" },
            { "fungus", "fungi" },
            { "nucleolus", "nucleoli" },
            { "torus", "tori" },
            { "genius", "genii" },
            { "radius", "radii" },
            { "umbilicus", "umbilici" },
            { "incubus", "incubi" },
            { "stylus", "styli" },
            { "uterus", "uteri" },
            { "stimulus", "stimuli" },
            { "apparatus", "apparatus" },
            { "impetus", "impetus" },
            { "prospectus", "prospectus" },
            { "cantus", "cantus" },
            { "nexus", "nexus" },
            { "sinus", "sinus" },
            { "coitus", "coitus" },
            { "plexus", "plexus" },
            { "status", "status" },
            { "hiatus", "hiatus" },
            { "afreet", "afreeti" },
            { "afrit", "afriti" },
            { "efreet", "efreeti" },
            { "cherub", "cherubim" },
            { "goy", "goyim" },
            { "seraph", "seraphim" },
            { "alumnus", "alumni" }
        };

        private List<string> _knownConflictingPluralList = new List<string>()
        {
            "they",
            "them",
            "their",
            "have",
            "were",
            "yourself",
            "are"
        };

        private Dictionary<string, string> _wordsEndingWithSeDictionary = new Dictionary<string, string>()
        {
            { "house", "houses" },
            { "case", "cases" },
            { "enterprise", "enterprises" },
            { "purchase", "purchases" },
            { "surprise", "surprises" },
            { "release", "releases" },
            { "disease", "diseases" },
            { "promise", "promises" },
            { "refuse", "refuses" },
            { "whose", "whoses" },
            { "phase", "phases" },
            { "noise", "noises" },
            { "nurse", "nurses" },
            { "rose", "roses" },
            { "franchise", "franchises" },
            { "supervise", "supervises" },
            { "farmhouse", "farmhouses" },
            { "suitcase", "suitcases" },
            { "recourse", "recourses" },
            { "impulse", "impulses" },
            { "license", "licenses" },
            { "diocese", "dioceses" },
            { "excise", "excises" },
            { "demise", "demises" },
            { "blouse", "blouses" },
            { "bruise", "bruises" },
            { "misuse", "misuses" },
            { "curse", "curses" },
            { "prose", "proses" },
            { "purse", "purses" },
            { "goose", "gooses" },
            { "tease", "teases" },
            { "poise", "poises" },
            { "vase", "vases" },
            { "fuse", "fuses" },
            { "muse", "muses" },
            { "slaughterhouse", "slaughterhouses" },
            { "clearinghouse", "clearinghouses" },
            { "endonuclease", "endonucleases" },
            { "steeplechase", "steeplechases" },
            { "metamorphose", "metamorphoses" },
            { "intercourse", "intercourses" },
            { "commonsense", "commonsenses" },
            { "intersperse", "intersperses" },
            { "merchandise", "merchandises" },
            { "phosphatase", "phosphatases" },
            { "summerhouse", "summerhouses" },
            { "watercourse", "watercourses" },
            { "catchphrase", "catchphrases" },
            { "compromise", "compromises" },
            { "greenhouse", "greenhouses" },
            { "lighthouse", "lighthouses" },
            { "paraphrase", "paraphrases" },
            { "mayonnaise", "mayonnaises" },
            { "racecourse", "racecourses" },
            { "apocalypse", "apocalypses" },
            { "courthouse", "courthouses" },
            { "powerhouse", "powerhouses" },
            { "storehouse", "storehouses" },
            { "glasshouse", "glasshouses" },
            { "hypotenuse", "hypotenuses" },
            { "peroxidase", "peroxidases" },
            { "pillowcase", "pillowcases" },
            { "roundhouse", "roundhouses" },
            { "streetwise", "streetwises" },
            { "expertise", "expertises" },
            { "discourse", "discourses" },
            { "warehouse", "warehouses" },
            { "staircase", "staircases" },
            { "workhouse", "workhouses" },
            { "briefcase", "briefcases" },
            { "clubhouse", "clubhouses" },
            { "clockwise", "clockwises" },
            { "concourse", "concourses" },
            { "playhouse", "playhouses" },
            { "turquoise", "turquoises" },
            { "boathouse", "boathouses" },
            { "cellulose", "celluloses" },
            { "epitomise", "epitomises" },
            { "gatehouse", "gatehouses" },
            { "grandiose", "grandioses" },
            { "menopause", "menopauses" },
            { "penthouse", "penthouses" },
            { "racehorse", "racehorses" },
            { "transpose", "transposes" },
            { "almshouse", "almshouses" },
            { "customise", "customises" },
            { "footloose", "footlooses" },
            { "galvanise", "galvanises" },
            { "princesse", "princesses" },
            { "universe", "universes" },
            { "workhorse", "workhorses" }
        };

        private Dictionary<string, string> _wordsEndingWithSisDictionary = new Dictionary<string, string>()
        {
            { "analysis", "analyses" },
            { "crisis", "crises" },
            { "basis", "bases" },
            { "atherosclerosis", "atheroscleroses" },
            { "electrophoresis", "electrophoreses" },
            { "psychoanalysis", "psychoanalyses" },
            { "photosynthesis", "photosyntheses" },
            { "amniocentesis", "amniocenteses" },
            { "metamorphosis", "metamorphoses" },
            { "toxoplasmosis", "toxoplasmoses" },
            { "endometriosis", "endometrioses" },
            { "tuberculosis", "tuberculoses" },
            { "pathogenesis", "pathogeneses" },
            { "osteoporosis", "osteoporoses" },
            { "parenthesis", "parentheses" },
            { "anastomosis", "anastomoses" },
            { "peristalsis", "peristalses" },
            { "hypothesis", "hypotheses" },
            { "antithesis", "antitheses" },
            { "apotheosis", "apotheoses" },
            { "thrombosis", "thromboses" },
            { "diagnosis", "diagnoses" },
            { "synthesis", "syntheses" },
            { "paralysis", "paralyses" },
            { "prognosis", "prognoses" },
            { "cirrhosis", "cirrhoses" },
            { "sclerosis", "scleroses" },
            { "psychosis", "psychoses" },
            { "apoptosis", "apoptoses" },
            { "symbiosis", "symbioses" }
        };

        private Dictionary<string, string> _wordsEndingWithSusDictionary = new Dictionary<string, string>()
        {
            { "consensus", "consensuses" },
            { "census", "censuses" }
        };

        private Dictionary<string, string> _wordsEndingWithInxAnxYnxDictionary = new Dictionary<string, string>()
        {
            { "sphinx", "sphinxes" },
            { "larynx", "larynges" },
            { "lynx", "lynxes" },
            { "pharynx", "pharynxes" },
            { "phalanx", "phalanxes" }
        };

        #endregion

        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="EnglishMetaDataAdapter"/>
        /// provider.
        /// </summary>
        protected EnglishMetaDataAdapter()
        {
            _culture = new CultureInfo("en-US");
            _userDictionary = new BidirectionalDictionary<string, string>();
            _irregularPluralsPluralizationService = new StringBidirectionalDictionary(_irregularPluralsDictionary);
            _assimilatedClassicalInflectionPluralizationService = new StringBidirectionalDictionary(_assimilatedClassicalInflectionDictionary);
            _oSuffixPluralizationService = new StringBidirectionalDictionary(_oSuffixDictionary);
            _classicalInflectionPluralizationService = new StringBidirectionalDictionary(_classicalInflectionDictionary);
            _wordsEndingWithSePluralizationService = new StringBidirectionalDictionary(_wordsEndingWithSeDictionary);
            _wordsEndingWithSisPluralizationService = new StringBidirectionalDictionary(_wordsEndingWithSisDictionary);
            _wordsEndingWithSusPluralizationService = new StringBidirectionalDictionary(_wordsEndingWithSusDictionary);
            _wordsEndingWithInxAnxYnxPluralizationService = new StringBidirectionalDictionary(_wordsEndingWithInxAnxYnxDictionary);
            _irregularVerbPluralizationService = new StringBidirectionalDictionary(_irregularVerbList);

            _knownSingluarWords = new List<string>(
                _irregularPluralsDictionary.Keys.Concat<string>(
                    _assimilatedClassicalInflectionDictionary.Keys
                ).Concat<string>(
                    _oSuffixDictionary.Keys
                ).Concat<string>(
                    _classicalInflectionDictionary.Keys
                ).Concat<string>(
                    _irregularVerbList.Keys
                ).Concat<string>(
                    _irregularPluralsDictionary.Keys
                ).Concat<string>(
                    _wordsEndingWithSeDictionary.Keys
                ).Concat<string>(
                    _wordsEndingWithSisDictionary.Keys
                ).Concat<string>(
                    _wordsEndingWithSusDictionary.Keys
                ).Concat<string>(
                    _wordsEndingWithInxAnxYnxDictionary.Keys
                ).Concat<string>(
                    _uninflectiveWordList
                ).Except<string>(
                    _knownConflictingPluralList
                ));

            _knownPluralWords = new List<string>(
                _irregularPluralsDictionary.Values.Concat<string>(
                    _assimilatedClassicalInflectionDictionary.Values
                ).Concat<string>(
                    _oSuffixDictionary.Values
                ).Concat<string>(
                    _classicalInflectionDictionary.Values
                ).Concat<string>(
                    _irregularVerbList.Values
                ).Concat<string>(
                    _irregularPluralsDictionary.Values
                ).Concat<string>(
                    _wordsEndingWithSeDictionary.Values
                ).Concat<string>(
                    _wordsEndingWithSisDictionary.Values
                ).Concat<string>(
                    _wordsEndingWithSusDictionary.Values
                ).Concat<string>(
                    _wordsEndingWithInxAnxYnxDictionary.Values
                ).Concat<string>(
                    _uninflectiveWordList
                ));
        }

        // *******************************************************************

        /// <summary>
        /// This constructor creates a new instance of the <see cref="EnglishMetaDataAdapter"/>
        /// provider.
        /// </summary>
        /// <param name="provider">The parent build provider.</param>
        public EnglishMetaDataAdapter(
            EnglishMetaDataProvider provider
        ) : this()
        {

        }

        #endregion

        // *******************************************************************
        // IMetaDataAdapter implementation.
        // *******************************************************************

        #region IMetaDataAdapter implementation

        /// <summary>
        /// This property indicates which language the adapter supports.
        /// </summary>
        public CultureInfo Culture
        {
            get { return _culture; }
        }

        // *******************************************************************

        /// <summary>
        /// This method determines if the specified word is plural.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <returns>True if the word is plural; otherwise, false.</returns>
        public bool IsPlural(
            string word
        )
        {
            if (_userDictionary.ExistsInSecond(word))
            {
                return true;
            }
            if (_userDictionary.ExistsInFirst(word))
            {
                return false;
            }
            if (IsUninflective(word) || _knownPluralWords.Contains(word.ToLower(_culture)))
            {
                return true;
            }
            if (Singularize(word).Equals(word))
            {
                return false;
            }
            return true;
        }

        // *******************************************************************

        /// <summary>
        /// This method determines if the specified word is singular.
        /// </summary>
        /// <param name="word">The word to test.</param>
        /// <returns>True if the word is singular; otherwise, false.</returns>
        public bool IsSingular(
            string word
        )
        {
            if (_userDictionary.ExistsInFirst(word))
            {
                return true;
            }
            if (_userDictionary.ExistsInSecond(word))
            {
                return false;
            }
            if (IsUninflective(word) || _knownSingluarWords.Contains(word.ToLower(_culture)))
            {
                return true;
            }
            if (!IsNoOpWord(word) && Singularize(word).Equals(word))
            {
                return true;
            }
            return false;
        }

        // *******************************************************************

        /// <summary>
        /// This method returns the plural form of the specified word
        /// </summary>
        /// <param name="word">The word to be made plural.</param>
        /// <returns>The plural form of the specified word.</returns>
        public string Pluralize(
            string word
        )
        {
            return Capitalize(word, new Func<string, string>(InternalPluralize));
        }

        // *******************************************************************

        /// <summary>
        /// This method returns the singular form of the specified word
        /// </summary>
        /// <param name="word">The word to be made singular.</param>
        /// <returns>The singular form of the specified word.</returns>
        public string Singularize(
            string word
        )
        {
            return Capitalize(word, new Func<string, string>(InternalSingularize));
        }

        // *******************************************************************

        /// <summary>
        /// This method adds a custom word to the adapter.
        /// </summary>
        /// <param name="singular">The singular version of the word.</param>
        /// <param name="plural">The plural version of the word.</param>
        public void AddWord(
            string singular,
            string plural
        )
        {
            if (_userDictionary.ExistsInSecond(plural))
            {
                //throw new ArgumentException(Strings.DuplicateEntryInUserDictionary("plural", plural), "plural");
                throw new ArgumentException();
            }
            if (_userDictionary.ExistsInFirst(singular))
            {
                //throw new ArgumentException(Strings.DuplicateEntryInUserDictionary("singular", singular), "singular");
                throw new ArgumentException();
            }
            _userDictionary.AddValue(singular, plural);
        }

        #endregion

        // *******************************************************************
        // Private methods.
        // *******************************************************************

        #region Private methods

        private string Capitalize(string word, Func<string, string> action)
        {
            string str = action(word);
            if (!IsCapitalized(word))
            {
                return str;
            }
            if (str.Length == 0)
            {
                return str;
            }
            StringBuilder stringBuilder = new StringBuilder(str.Length);
            stringBuilder.Append(char.ToUpperInvariant(str[0]));
            stringBuilder.Append(str.Substring(1));
            return stringBuilder.ToString();
        }

        private string GetSuffixWord(string word, out string prefixWord)
        {
            int num = word.LastIndexOf(' ');
            prefixWord = word.Substring(0, num + 1);
            return word.Substring(num + 1);
        }

        private string InternalPluralize(string word)
        {
            string str;
            string str1;
            if (_userDictionary.ExistsInFirst(word))
            {
                return _userDictionary.GetSecondValue(word);
            }
            if (IsNoOpWord(word))
            {
                return word;
            }
            string suffixWord = GetSuffixWord(word, out str);
            if (IsNoOpWord(suffixWord))
            {
                return string.Concat(str, suffixWord);
            }
            if (IsUninflective(suffixWord))
            {
                return string.Concat(str, suffixWord);
            }
            if (_knownPluralWords.Contains(suffixWord.ToLowerInvariant()) || IsPlural(suffixWord))
            {
                return string.Concat(str, suffixWord);
            }
            if (_irregularPluralsPluralizationService.ExistsInFirst(suffixWord))
            {
                return string.Concat(str, _irregularPluralsPluralizationService.GetSecondValue(suffixWord));
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "man"
            }, (string s) => string.Concat(s.Remove(s.Length - 2, 2), "en"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "louse",
                "mouse"
            }, (string s) => string.Concat(s.Remove(s.Length - 4, 4), "ice"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "tooth"
            }, (string s) => string.Concat(s.Remove(s.Length - 4, 4), "eeth"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "goose"
            }, (string s) => string.Concat(s.Remove(s.Length - 4, 4), "eese"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "foot"
            }, (string s) => string.Concat(s.Remove(s.Length - 3, 3), "eet"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "zoon"
            }, (string s) => string.Concat(s.Remove(s.Length - 3, 3), "oa"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "cis",
                "sis",
                "xis"
            }, (string s) => string.Concat(s.Remove(s.Length - 2, 2), "es"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (_assimilatedClassicalInflectionPluralizationService.ExistsInFirst(suffixWord))
            {
                return string.Concat(str, _assimilatedClassicalInflectionPluralizationService.GetSecondValue(suffixWord));
            }
            if (_classicalInflectionPluralizationService.ExistsInFirst(suffixWord))
            {
                return string.Concat(str, _classicalInflectionPluralizationService.GetSecondValue(suffixWord));
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "trix"
            }, (string s) => string.Concat(s.Remove(s.Length - 1, 1), "ces"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "eau",
                "ieu"
            }, (string s) => string.Concat(s, "x"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (_wordsEndingWithInxAnxYnxPluralizationService.ExistsInFirst(suffixWord))
            {
                return string.Concat(str, _wordsEndingWithInxAnxYnxPluralizationService.GetSecondValue(suffixWord));
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "ch",
                "sh",
                "ss"
            }, (string s) => string.Concat(s, "es"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "alf",
                "elf",
                "olf",
                "eaf",
                "arf"
            }, (string s) => {
                if (s.EndsWith("deaf", true, _culture))
                {
                    return s;
                }
                return string.Concat(s.Remove(s.Length - 1, 1), "ves");
            }, _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "nife",
                "life",
                "wife"
            }, (string s) => string.Concat(s.Remove(s.Length - 2, 2), "ves"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "ay",
                "ey",
                "iy",
                "oy",
                "uy"
            }, (string s) => string.Concat(s, "s"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (suffixWord.EndsWith("y", true, _culture))
            {
                return string.Concat(str, suffixWord.Remove(suffixWord.Length - 1, 1), "ies");
            }
            if (_oSuffixPluralizationService.ExistsInFirst(suffixWord))
            {
                return string.Concat(str, _oSuffixPluralizationService.GetSecondValue(suffixWord));
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "ao",
                "eo",
                "io",
                "oo",
                "uo"
            }, (string s) => string.Concat(s, "s"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (suffixWord.EndsWith("o", true, _culture) || suffixWord.EndsWith("s", true, _culture))
            {
                return string.Concat(str, suffixWord, "es");
            }
            if (suffixWord.EndsWith("x", true, _culture))
            {
                return string.Concat(str, suffixWord, "es");
            }
            return string.Concat(str, suffixWord, "s");
        }

        private string InternalSingularize(string word)
        {
            string str;
            string str1;
            if (_userDictionary.ExistsInSecond(word))
            {
                return _userDictionary.GetFirstValue(word);
            }
            if (IsNoOpWord(word))
            {
                return word;
            }
            string suffixWord = GetSuffixWord(word, out str);
            if (IsNoOpWord(suffixWord))
            {
                return string.Concat(str, suffixWord);
            }
            if (IsUninflective(suffixWord))
            {
                return string.Concat(str, suffixWord);
            }
            if (_knownSingluarWords.Contains(suffixWord.ToLowerInvariant()))
            {
                return string.Concat(str, suffixWord);
            }
            if (_irregularVerbPluralizationService.ExistsInSecond(suffixWord))
            {
                return string.Concat(str, _irregularVerbPluralizationService.GetFirstValue(suffixWord));
            }
            if (_irregularPluralsPluralizationService.ExistsInSecond(suffixWord))
            {
                return string.Concat(str, _irregularPluralsPluralizationService.GetFirstValue(suffixWord));
            }
            if (_wordsEndingWithSisPluralizationService.ExistsInSecond(suffixWord))
            {
                return string.Concat(str, _wordsEndingWithSisPluralizationService.GetFirstValue(suffixWord));
            }
            if (_wordsEndingWithSePluralizationService.ExistsInSecond(suffixWord))
            {
                return string.Concat(str, _wordsEndingWithSePluralizationService.GetFirstValue(suffixWord));
            }
            if (_wordsEndingWithSusPluralizationService.ExistsInSecond(suffixWord))
            {
                return string.Concat(str, _wordsEndingWithSusPluralizationService.GetFirstValue(suffixWord));
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "men"
            }, (string s) => string.Concat(s.Remove(s.Length - 2, 2), "an"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "lice",
                "mice"
            }, (string s) => string.Concat(s.Remove(s.Length - 3, 3), "ouse"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "teeth"
            }, (string s) => string.Concat(s.Remove(s.Length - 4, 4), "ooth"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "geese"
            }, (string s) => string.Concat(s.Remove(s.Length - 4, 4), "oose"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "feet"
            }, (string s) => string.Concat(s.Remove(s.Length - 3, 3), "oot"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "zoa"
            }, (string s) => string.Concat(s.Remove(s.Length - 2, 2), "oon"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "ches",
                "shes",
                "sses"
            }, (string s) => s.Remove(s.Length - 2, 2), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (_assimilatedClassicalInflectionPluralizationService.ExistsInSecond(suffixWord))
            {
                return string.Concat(str, _assimilatedClassicalInflectionPluralizationService.GetFirstValue(suffixWord));
            }
            if (_classicalInflectionPluralizationService.ExistsInSecond(suffixWord))
            {
                return string.Concat(str, _classicalInflectionPluralizationService.GetFirstValue(suffixWord));
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "trices"
            }, (string s) => string.Concat(s.Remove(s.Length - 3, 3), "x"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "eaux",
                "ieux"
            }, (string s) => s.Remove(s.Length - 1, 1), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (_wordsEndingWithInxAnxYnxPluralizationService.ExistsInSecond(suffixWord))
            {
                return string.Concat(str, _wordsEndingWithInxAnxYnxPluralizationService.GetFirstValue(suffixWord));
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "alves",
                "elves",
                "olves",
                "eaves",
                "arves"
            }, (string s) => string.Concat(s.Remove(s.Length - 3, 3), "f"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "nives",
                "lives",
                "wives"
            }, (string s) => string.Concat(s.Remove(s.Length - 3, 3), "fe"), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "ays",
                "eys",
                "iys",
                "oys",
                "uys"
            }, (string s) => s.Remove(s.Length - 1, 1), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (suffixWord.EndsWith("ies", true, _culture))
            {
                return string.Concat(str, suffixWord.Remove(suffixWord.Length - 3, 3), "y");
            }
            if (_oSuffixPluralizationService.ExistsInSecond(suffixWord))
            {
                return string.Concat(str, _oSuffixPluralizationService.GetFirstValue(suffixWord));
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "aos",
                "eos",
                "ios",
                "oos",
                "uos"
            }, (string s) => suffixWord.Remove(suffixWord.Length - 1, 1), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "ces"
            }, (string s) => s.Remove(s.Length - 1, 1), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (PluralizationServiceUtil.TryInflectOnSuffixInWord(suffixWord, new List<string>()
            {
                "ces",
                "ses",
                "xes"
            }, (string s) => s.Remove(s.Length - 2, 2), _culture, out str1))
            {
                return string.Concat(str, str1);
            }
            if (suffixWord.EndsWith("oes", true, _culture))
            {
                return string.Concat(str, suffixWord.Remove(suffixWord.Length - 2, 2));
            }
            if (suffixWord.EndsWith("ss", true, _culture))
            {
                return string.Concat(str, suffixWord);
            }
            if (!suffixWord.EndsWith("s", true, _culture))
            {
                return string.Concat(str, suffixWord);
            }
            return string.Concat(str, suffixWord.Remove(suffixWord.Length - 1, 1));
        }

        private bool IsAlphabets(string word)
        {
            if (!string.IsNullOrEmpty(word.Trim()) && word.Equals(word.Trim()) && !Regex.IsMatch(word, "[^a-zA-Z\\s]"))
            {
                return true;
            }
            return false;
        }

        private bool IsCapitalized(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }
            return char.IsUpper(word, 0);
        }

        private bool IsNoOpWord(string word)
        {
            if (IsAlphabets(word) && word.Length > 1 && !_pronounList.Contains(word.ToLowerInvariant()))
            {
                return false;
            }
            return true;
        }

        private bool IsUninflective(string word)
        {
            //EDesignUtil.CheckArgumentNull<string>(word, "word");
            if (!PluralizationServiceUtil.DoesWordContainSuffix(word, _uninflectiveSuffixList, _culture) && (word.ToLower(_culture).Equals(word) || !word.EndsWith("ese", false, _culture)) && !_uninflectiveWordList.Contains<string>(word.ToLowerInvariant()))
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
