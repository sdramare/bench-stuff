using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace BenchStash
{
    [MemoryDiagnoser(true)]
    public class TestSwitch
    {
        private readonly Dictionary<string, string> _map = new()
        {
            { "deposit", "tisoped" },
            { "invoice", "eciovni" },
            { "Sleek", "keelS" },
            { "Unbranded Granite Mouse", "esuoM etinarG dednarbnU" },
            { "Michigan", "nagihciM" },
            { "secondary", "yradnoces" },
            { "reboot", "toober" },
            { "Outdoors", "sroodtuO" },
            { "Cliff", "ffilC" },
            { "ivory", "yrovi" },
            { "partnerships", "spihsrentrap" },
            { "Home Loan Account", "tnuoccA naoL emoH" },
            { "Cambridgeshire", "erihsegdirbmaC" },
            { "redefine", "enifeder" },
            { "Kyrgyz Republic", "cilbupeR zygryK" },
            { "Analyst", "tsylanA" },
            { "Ameliorated", "detaroilemA" },
            { "New Mexico", "ocixeM weN" },
            { "monetize", "ezitenom" },
            { "circuit", "tiucric" },
            { "Fresh", "hserF" },
            { "Ergonomic Rubber Keyboard", "draobyeK rebbuR cimonogrE" },
            { "Garden", "nedraG" },
            { "Human", "namuH" },
            { "RSS", "SSR" },
            { "morph", "hprom" },
            { "Intranet", "tenartnI" },
            { "Rustic", "citsuR" },
            { "Assimilated", "detalimissA" },
            { "Response", "esnopseR" },
            { "internet solution", "noitulos tenretni" },
            { "XML", "LMX" },
            { "Mountain", "niatnuoM" },
            { "encompassing", "gnissapmocne" },
            { "multimedia", "aidemitlum" },
            { "Washington", "notgnihsaW" },
            { "Walk", "klaW" },
            { "transparent", "tnerapsnart" },
            { "Rubber", "rebbuR" },
            { "Steel", "leetS" },
            { "synthesizing", "gnizisehtnys" },
            { "Shores", "serohS" },
            { "SAS", "SAS" },
            { "Right-sized", "dezis-thgiR" },
            { "modular", "raludom" },
            { "Soft", "tfoS" },
            { "Regional", "lanoigeR" },
            { "Re-engineered", "dereenigne-eR" },
            { "Codes specifically reserved for testing purposes", "sesoprup gnitset rof devreser yllacificeps sedoC" },
            { "Principal", "lapicnirP" },
            { "Expanded", "dednapxE" },
            { "Orchestrator", "rotartsehcrO" },
            { "e-services", "secivres-e" },
            { "black", "kcalb" },
            { "Belarussian Ruble", "elbuR naissuraleB" },
            { "virtual", "lautriv" },
            { "Latvian Lats", "staL naivtaL" },
            { "input", "tupni" },
            { "Turkish Lira", "ariL hsikruT" },
            { "Sudanese Pound", "dnuoP esenaduS" },
            { "Iceland Krona", "anorK dnalecI" },
            { "Falkland Islands Pound", "dnuoP sdnalsI dnalklaF" },
            { "Planner", "rennalP" },
            { "primary", "yramirp" },
            { "Handmade Concrete Shoes", "seohS etercnoC edamdnaH" },
            { "Hong Kong", "gnoK gnoH" },
            { "copy", "ypoc" },
            { "functionalities", "seitilanoitcnuf" },
            { "Bridge", "egdirB" },
            { "Communications", "snoitacinummoC" },
            { "bandwidth-monitored", "derotinom-htdiwdnab" },
            { "calculating", "gnitaluclac" },
            { "Representative", "evitatneserpeR" },
            { "asynchronous", "suonorhcnysa" },
            { "intangible", "elbignatni" },
            { "Direct", "tceriD" },
            { "seamless", "sselmaes" },
            { "Place", "ecalP" },
            { "Ergonomic", "cimonogrE" },
            { "Generic Frozen Gloves", "sevolG nezorF cireneG" },
            { "Sri Lanka Rupee", "eepuR aknaL irS" },
            { "extend", "dnetxe" },
            { "Programmable", "elbammargorP" },
            { "synthesize", "ezisehtnys" },
            { "Club", "bulC" },
            { "Facilitator", "rotatilicaF" },
            { "bandwidth", "htdiwdnab" },
            { "Wooden", "nedooW" },
            { "Dale", "elaD" },
            { "silver", "revlis" },
            { "hacking", "gnikcah" },
            { "Wyoming", "gnimoyW" },
            { "Kansas", "sasnaK" },
            { "Internal", "lanretnI" },
            { "North Dakota", "atokaD htroN" },
            { "Awesome Steel Hat", "taH leetS emosewA" },
            { "Mississippi", "ippississiM" },
            { "HDD", "DDH" },
            { "bus", "sub" },
            { "Refined Wooden Table", "elbaT nedooW denifeR" },
            { "PCI", "ICP" },
            { "recontextualize", "ezilautxetnocer" },
            { "Borders", "sredroB" },
            { "Enhanced", "decnahnE" },
            { "Practical", "lacitcarP" },
            { "calculate", "etaluclac" },
            { "microchip", "pihcorcim" },
            { "Generic", "cireneG" },
            { "Wisconsin", "nisnocsiW" },
            { "mission-critical", "lacitirc-noissim" },
            { "User-centric", "cirtnec-resU" },
            { "Designer", "rengiseD" },
            { "Concrete", "etercnoC" },
            { "parsing", "gnisrap" },
            { "Generic Plastic Keyboard", "draobyeK citsalP cireneG" },
            { "Practical Cotton Table", "elbaT nottoC lacitcarP" },
            { "Profound", "dnuoforP" },
            { "Fiji", "ijiF" },
            { "Awesome", "emosewA" },
            { "secured line", "enil deruces" },
            { "alarm", "mrala" },
            { "tangible", "elbignat" },
            { "models", "sledom" },
            { "Auto Loan Account", "tnuoccA naoL otuA" },
            { "firewall", "llawerif" },
            { "New Hampshire", "erihspmaH weN" },
            { "Liaison", "nosiaiL" },
            { "Unbranded", "dednarbnU" },
            { "Turnpike", "ekipnruT" },
            { "Music \u0026 Kids", "sdiK \u0026 cisuM" },
            { "yellow", "wolley" },
            { "pixel", "lexip" },
            { "Frozen", "nezorF" },
            { "navigating", "gnitagivan" },
            { "Fully-configurable", "elbarugifnoc-ylluF" },
            { "brand", "dnarb" },
            { "Chief", "feihC" },
            { "Republic of Korea", "aeroK fo cilbupeR" },
            { "Grocery \u0026 Beauty", "ytuaeB \u0026 yrecorG" },
            { "Avon", "novA" },
            { "withdrawal", "lawardhtiw" },
            { "Fantastic", "citsatnaF" },
            { "back-end", "dne-kcab" },
            { "Norfolk Island", "dnalsI klofroN" },
            { "Guinea Franc", "cnarF aeniuG" },
            { "Solutions", "snoituloS" },
            { "monitoring", "gnirotinom" },
            { "Developer", "repoleveD" },
            { "website", "etisbew" },
            { "Global", "labolG" },
            { "Generic Soft Shirt", "trihS tfoS cireneG" },
            { "Credit Card Account", "tnuoccA draC tiderC" },
            { "Sleek Plastic Soap", "paoS citsalP keelS" },
            { "cutting-edge", "egde-gnittuc" },
            { "Dominican Republic", "cilbupeR nacinimoD" },
            { "Functionality", "ytilanoitcnuF" },
            { "contextually-based", "desab-yllautxetnoc" },
            { "Yemen", "nemeY" },
            { "generating", "gnitareneg" },
            { "PNG", "GNP" },
            { "Solomon Islands", "sdnalsI nomoloS" },
            { "cultivate", "etavitluc" },
            { "Personal Loan Account", "tnuoccA naoL lanosreP" },
            { "Research", "hcraeseR" },
            { "Bedfordshire", "erihsdrofdeB" },
            { "Paradigm", "mgidaraP" },
            { "Directives", "sevitceriD" },
            { "online", "enilno" },
            { "Granite", "etinarG" },
            { "Seychelles Rupee", "eepuR sellehcyeS" },
            { "Circle", "elcriC" },
            { "Underpass", "ssaprednU" },
            { "Tugrik", "kirguT" },
            { "matrix", "xirtam" },
            { "bifurcated", "detacrufib" },
            { "Savings Account", "tnuoccA sgnivaS" },
            { "incentivize", "ezivitnecni" },
            { "Vision-oriented", "detneiro-noisiV" },
            { "compelling", "gnillepmoc" },
            { "Hawaii", "iiawaH" },
            { "Handcrafted Wooden Cheese", "eseehC nedooW detfarcdnaH" },
            { "Program", "margorP" },
            { "Gold", "dloG" },
            { "Up-sized", "dezis-pU" },
            { "Tokelau", "ualekoT" },
            { "payment", "tnemyap" },
            { "lavender", "redneval" },
            { "Trace", "ecarT" },
            { "Licensed Plastic Keyboard", "draobyeK citsalP desneciL" },
            { "Pike", "ekiP" },
            { "Refined", "denifeR" },
            { "Quality-focused", "desucof-ytilauQ" },
            { "grow", "worg" },
            { "Ecuador", "rodaucE" },
            { "HTTP", "PTTH" },
            { "Music, Tools \u0026 Automotive", "evitomotuA \u0026 slooT ,cisuM" },
            { "Creative", "evitaerC" },
            { "hard drive", "evird drah" },
            { "transmit", "timsnart" },
            { "syndicate", "etacidnys" },
            { "Yuan Renminbi", "ibnimneR nauY" },
            { "Horizontal", "latnoziroH" },
            { "Garden \u0026 Automotive", "evitomotuA \u0026 nedraG" },
            { "bluetooth", "htooteulb" },
            { "Mauritius", "suitiruaM" },
            { "Fantastic Cotton Fish", "hsiF nottoC citsatnaF" },
            { "Barbados", "sodabraB" },
            { "value-added", "dedda-eulav" },
            { "Silver", "revliS" },
            { "B2B", "B2B" },
            { "Kwanza", "aznawK" },
            { "Union", "noinU" },
            { "Strategist", "tsigetartS" },
            { "engage", "egagne" },
            { "synergistic", "citsigrenys" },
            { "seize", "ezies" },
            { "cross-platform", "mroftalp-ssorc" },
            { "Small Wooden Chicken", "nekcihC nedooW llamS" },
            { "Israel", "learsI" },
            { "Berkshire", "erihskreB" },
            { "Kids, Garden \u0026 Kids", "sdiK \u0026 nedraG ,sdiK" },
            { "leading-edge", "egde-gnidael" },
            { "Gibraltar Pound", "dnuoP ratlarbiG" },
            { "interface", "ecafretni" },
            { "transition", "noitisnart" },
            { "4th generation", "noitareneg ht4" },
            { "index", "xedni" },
            { "Arkansas", "sasnakrA" },
            { "multi-tasking", "gniksat-itlum" },
            { "end-to-end", "dne-ot-dne" },
            { "application", "noitacilppa" },
            { "programming", "gnimmargorp" },
            { "access", "ssecca" },
            { "Awesome Granite Pizza", "azziP etinarG emosewA" },
            { "Intelligent Concrete Table", "elbaT etercnoC tnegilletnI" },
            { "front-end", "dne-tnorf" },
            { "Fields", "sdleiF" },
            { "Clothing", "gnihtolC" },
            { "green", "neerg" },
            { "Buckinghamshire", "erihsmahgnikcuB" },
            { "Shoal", "laohS" },
            { "Handmade Rubber Car", "raC rebbuR edamdnaH" },
            { "bricks-and-clicks", "skcilc-dna-skcirb" },
            { "experiences", "secneirepxe" },
            { "revolutionary", "yranoitulover" },
            { "systems", "smetsys" },
            { "Rapids", "sdipaR" },
            { "JSON", "NOSJ" },
            { "South Carolina", "aniloraC htuoS" },
            { "Intelligent", "tnegilletnI" },
            { "Ergonomic Fresh Shoes", "seohS hserF cimonogrE" },
            { "Kenyan Shilling", "gnillihS nayneK" },
            { "Nuevo Sol", "loS oveuN" },
            { "Cliffs", "sffilC" },
            { "reintermediate", "etaidemretnier" },
            { "Overpass", "ssaprevO" },
            { "Camp", "pmaC" },
            { "Maryland", "dnalyraM" },
            { "grey", "yerg" },
            { "Sleek Frozen Ball", "llaB nezorF keelS" },
            { "Dominica", "acinimoD" },
            { "human-resource", "ecruoser-namuh" },
            { "Shoes", "seohS" },
            { "framework", "krowemarf" },
            { "Corporate", "etaroproC" },
            { "Points", "stnioP" },
            { "Maine", "eniaM" },
            { "Ergonomic Steel Ball", "llaB leetS cimonogrE" },
            { "Multi-channelled", "dellennahc-itluM" },
            { "program", "margorp" },
            { "engineer", "reenigne" },
            { "THX", "XHT" },
            { "Licensed Metal Car", "raC lateM desneciL" },
            { "24/7", "7/42" },
            { "concept", "tpecnoc" },
            { "deliverables", "selbareviled" },
            { "Netherlands Antilles", "sellitnA sdnalrehteN" },
            { "Fantastic Granite Keyboard", "draobyeK etinarG citsatnaF" },
            { "teal", "laet" },
            { "24/365", "563/42" },
            { "interactive", "evitcaretni" },
            { "back up", "pu kcab" },
            { "Square", "erauqS" },
            { "neural", "laruen" },
            { "Kids \u0026 Home", "emoH \u0026 sdiK" },
            { "Automotive \u0026 Music", "cisuM \u0026 evitomotuA" },
            { "sky blue", "eulb yks" },
            { "Ramp", "pmaR" },
            { "pricing structure", "erutcurts gnicirp" },
            { "Bermuda", "adumreB" },
            { "methodology", "ygolodohtem" },
            { "Falls", "sllaF" },
            { "Mission", "noissiM" },
            { "interfaces", "secafretni" },
            { "USB", "BSU" },
            { "Plastic", "citsalP" },
            { "Handcrafted Soft Chips", "spihC tfoS detfarcdnaH" },
            { "El Salvador", "rodavlaS lE" },
            { "Digitized", "dezitigiD" },
            { "Reunion", "noinueR" },
            { "Pre-emptive", "evitpme-erP" },
            { "Assistant", "tnatsissA" },
            { "Interactions", "snoitcaretnI" },
            { "GB", "BG" },
            { "South Dakota", "atokaD htuoS" },
            { "Canyon", "noynaC" },
            { "Guadeloupe", "epuoledauG" },
            { "Intuitive", "evitiutnI" },
            { "Small Soft Bacon", "nocaB tfoS llamS" },
            { "copying", "gniypoc" },
            { "Tasty Steel Chips", "spihC leetS ytsaT" },
            { "Fantastic Metal Sausages", "segasuaS lateM citsatnaF" },
            { "Generic Plastic Soap", "paoS citsalP cireneG" },
            { "protocol", "locotorp" },
            { "relationships", "spihsnoitaler" },
            { "maroon", "nooram" },
            { "capacitor", "roticapac" },
            { "Specialist", "tsilaicepS" },
            { "Officer", "reciffO" },
            { "AGP", "PGA" },
            { "Supervisor", "rosivrepuS" },
            { "Assurance", "ecnarussA" },
            { "Customer", "remotsuC" },
            { "Money Market Account", "tnuoccA tekraM yenoM" },
            { "architectures", "serutcetihcra" },
            { "magenta", "atnegam" },
            { "markets", "stekram" },
            { "array", "yarra" },
            { "Branding", "gnidnarB" },
            { "Central", "lartneC" },
            { "regional", "lanoiger" },
            { "Graphic Interface", "ecafretnI cihparG" },
            { "Road", "daoR" },
            { "hardware", "erawdrah" },
            { "system", "metsys" },
            { "Jordan", "nadroJ" },
            { "intuitive", "evitiutni" },
            { "Consultant", "tnatlusnoC" },
            { "New York", "kroY weN" },
            { "Dobra", "arboD" },
            { "compress", "sserpmoc" },
            { "Norwegian Krone", "enorK naigewroN" },
            { "supply-chains", "sniahc-ylppus" },
            { "Generic Plastic Gloves", "sevolG citsalP cireneG" },
            { "fuchsia", "aishcuf" },
            { "Optimization", "noitazimitpO" },
            { "Data", "ataD" },
            { "Lithuanian Litas", "satiL nainauhtiL" },
            { "enterprise", "esirpretne" },
            { "action-items", "smeti-noitca" },
            { "Sleek Steel Shoes", "seohS leetS keelS" },
            { "Metal", "lateM" },
            { "Uganda Shilling", "gnillihS adnagU" },
            { "International", "lanoitanretnI" },
            { "Tools", "slooT" },
            { "Computers, Beauty \u0026 Health", "htlaeH \u0026 ytuaeB ,sretupmoC" },
            { "Engineer", "reenignE" },
            { "Movies, Home \u0026 Automotive", "evitomotuA \u0026 emoH ,seivoM" },
            { "Dynamic", "cimanyD" },
            { "Incredible Rubber Tuna", "anuT rebbuR elbidercnI" },
            { "digital", "latigid" },
            { "Canada", "adanaC" },
            { "Trail", "liarT" },
            { "Gorgeous", "suoegroG" },
            { "Licensed Metal Tuna", "anuT lateM desneciL" },
            { "Sports \u0026 Baby", "ybaB \u0026 stropS" },
            { "Legacy", "ycageL" },
            { "Industrial \u0026 Automotive", "evitomotuA \u0026 lairtsudnI" },
            { "open-source", "ecruos-nepo" },
            { "next-generation", "noitareneg-txen" },
            { "transform", "mrofsnart" },
            { "JBOD", "DOBJ" },
            { "well-modulated", "detaludom-llew" },
            { "Checking Account", "tnuoccA gnikcehC" },
            { "Kids", "sdiK" },
            { "Investor", "rotsevnI" },
            { "frictionless", "sselnoitcirf" },
            { "overriding", "gnidirrevo" },
            { "customized", "dezimotsuc" },
            { "SCSI", "ISCS" },
            { "Groves", "sevorG" },
            { "Isle", "elsI" },
            { "backing up", "pu gnikcab" },
            { "Platinum", "munitalP" },
            { "card", "drac" },
            { "Toys \u0026 Sports", "stropS \u0026 syoT" },
            { "Small Granite Bike", "ekiB etinarG llamS" },
            { "open architecture", "erutcetihcra nepo" },
            { "Open-source", "ecruos-nepO" },
            { "Handmade Frozen Pizza", "azziP nezorF edamdnaH" },
            { "quantifying", "gniyfitnauq" },
            { "El Salvador Colon", "noloC rodavlaS lE" },
            { "Texas", "saxeT" },
            { "azure", "eruza" },
            { "Executive", "evitucexE" },
            { "Corner", "renroC" },
            { "integrated", "detargetni" },
            { "wireless", "sseleriw" },
            { "challenge", "egnellahc" },
            { "hack", "kcah" },
            { "Utah", "hatU" },
            { "Home, Electronics \u0026 Jewelery", "yreleweJ \u0026 scinortcelE ,emoH" },
            { "Illinois", "sionillI" },
            { "Ergonomic Wooden Tuna", "anuT nedooW cimonogrE" },
            { "Refined Steel Table", "elbaT leetS denifeR" },
            { "approach", "hcaorppa" },
            { "haptic", "citpah" },
            { "European Unit of Account 9(E.U.A.-9)", ")9-.A.U.E(9 tnuoccA fo tinU naeporuE" },
            { "Tasty", "ytsaT" },
            { "Managed", "deganaM" },
            { "Investment Account", "tnuoccA tnemtsevnI" },
            { "Idaho", "ohadI" },
            { "SDD", "DDS" },
            { "Plaza", "azalP" },
            { "deliver", "reviled" },
            { "Unbranded Plastic Gloves", "sevolG citsalP dednarbnU" },
            { "optimize", "ezimitpo" },
            { "Via", "aiV" },
            { "gold", "dlog" },
            { "Path", "htaP" },
            { "Gorgeous Frozen Salad", "dalaS nezorF suoegroG" },
            { "violet", "teloiv" },
            { "Small", "llamS" },
            { "enhance", "ecnahne" },
            { "architect", "tcetihcra" },
            { "Shoes \u0026 Garden", "nedraG \u0026 seohS" },
            { "Meadow", "wodaeM" },
            { "transmitting", "gnittimsnart" },
            { "Cotton", "nottoC" },
            { "Hollow", "wolloH" },
            { "applications", "snoitacilppa" },
            { "Street", "teertS" },
            { "Kentucky", "ykcutneK" },
            { "Hills", "slliH" },
            { "impactful", "luftcapmi" },
            { "New Caledonia", "ainodelaC weN" },
            { "Ridge", "egdiR" },
            { "purple", "elprup" },
            { "Marketing", "gnitekraM" },
            { "Norway", "yawroN" },
            { "Tasty Wooden Sausages", "segasuaS nedooW ytsaT" },
            { "Agent", "tnegA" },
            { "Accountability", "ytilibatnuoccA" },
            { "Sleek Rubber Towels", "slewoT rebbuR keelS" },
            { "Cordoba Oro", "orO abodroC" },
            { "encoding", "gnidocne" },
            { "Division", "noisiviD" },
            { "District", "tcirtsiD" },
            { "user-centric", "cirtnec-resu" },
            { "Practical Concrete Ball", "llaB etercnoC lacitcarP" },
            { "multi-byte", "etyb-itlum" },
            { "IB", "BI" },
            { "Uganda", "adnagU" },
            { "unleash", "hsaelnu" },
            { "Handcrafted Soft Keyboard", "draobyeK tfoS detfarcdnaH" },
            { "Shore", "erohS" },
            { "Director", "rotceriD" },
            { "architecture", "erutcetihcra" },
            { "Mozambique", "euqibmazoM" },
            { "explicit", "ticilpxe" },
            { "infrastructures", "serutcurtsarfni" },
            {
                "Bond Markets Units European Composite Unit (EURCO)",
                ")OCRUE( tinU etisopmoC naeporuE stinU stekraM dnoB"
            },
            { "Keys", "syeK" },
            { "e-markets", "stekram-e" },
            { "Business-focused", "desucof-ssenisuB" },
            { "Small Frozen Hat", "taH nezorF llamS" },
            { "Rustic Wooden Sausages", "segasuaS nedooW citsuR" },
            { "plug-and-play", "yalp-dna-gulp" },
            { "visualize", "ezilausiv" },
            { "Licensed Concrete Computer", "retupmoC etercnoC desneciL" },
            { "Burgs", "sgruB" },
            { "Versatile", "elitasreV" },
            { "Practical Rubber Chicken", "nekcihC rebbuR lacitcarP" },
            { "Generic Granite Ball", "llaB etinarG cireneG" },
            { "bleeding-edge", "egde-gnideelb" },
            { "Locks", "skcoL" },
            { "orchid", "dihcro" },
            { "Handmade Steel Keyboard", "draobyeK leetS edamdnaH" },
            { "Product", "tcudorP" },
            { "Nevada", "adaveN" },
            { "Synergized", "dezigrenyS" },
            { "indexing", "gnixedni" },
            { "plum", "mulp" },
            { "Baby", "ybaB" },
            { "Skyway", "yawykS" },
            { "Junction", "noitcnuJ" },
            { "Ergonomic Fresh Gloves", "sevolG hserF cimonogrE" },
            { "portals", "slatrop" },
            { "capability", "ytilibapac" },
            { "Intelligent Cotton Soap", "paoS nottoC tnegilletnI" },
            { "strategize", "ezigetarts" },
            { "Electronics", "scinortcelE" },
            { "Awesome Fresh Chicken", "nekcihC hserF emosewA" },
            { "Passage", "egassaP" },
            { "orange", "egnaro" },
            { "Malawi", "iwalaM" },
            { "exuding", "gniduxe" },
            { "Technician", "naicinhceT" },
            { "View", "weiV" },
            { "Intelligent Plastic Salad", "dalaS citsalP tnegilletnI" },
            { "Montana", "anatnoM" },
            { "uniform", "mrofinu" },
            { "Lebanese Pound", "dnuoP esenabeL" },
            { "Indiana", "anaidnI" },
            { "optical", "lacitpo" },
            { "Incredible Concrete Bike", "ekiB etercnoC elbidercnI" },
            { "Saudi Riyal", "layiR iduaS" },
            { "generate", "etareneg" },
            { "Moldova", "avodloM" },
            { "driver", "revird" },
            { "Swiss Franc", "cnarF ssiwS" },
            { "Mobility", "ytiliboM" },
            { "Guinea", "aeniuG" },
            { "ability", "ytiliba" },
            { "Curve", "evruC" },
            { "Flat", "talF" },
            { "transmitter", "rettimsnart" },
            { "Outdoors, Clothing \u0026 Games", "semaG \u0026 gnihtolC ,sroodtuO" },
            { "Health, Movies \u0026 Books", "skooB \u0026 seivoM ,htlaeH" },
            { "Mountains", "sniatnuoM" },
            { "Identity", "ytitnedI" },
            { "budgetary management", "tnemeganam yrategdub" },
            { "Isle of Man", "naM fo elsI" },
            { "full-range", "egnar-lluf" },
            { "directional", "lanoitcerid" },
            { "SQL", "LQS" },
            { "Configurable", "elbarugifnoC" },
            { "Awesome Rubber Chicken", "nekcihC rebbuR emosewA" },
            { "Group", "puorG" },
            { "Island", "dnalsI" },
            { "Handmade Fresh Hat", "taH hserF edamdnaH" },
            { "Guarani", "inarauG" },
            { "harness", "ssenrah" },
            { "Usability", "ytilibasU" },
            { "override", "edirrevo" },
            { "heuristic", "citsirueh" },
            { "Uruguay", "yaugurU" },
            { "Handmade", "edamdnaH" },
            { "global", "labolg" },
            { "Fantastic Soft Shirt", "trihS tfoS citsatnaF" },
            { "solid state", "etats dilos" },
            { "Roads", "sdaoR" },
            { "bypassing", "gnissapyb" },
            { "Station", "noitatS" },
            { "Licensed Fresh Pizza", "azziP hserF desneciL" },
            { "blockchains", "sniahckcolb" },
            { "Land", "dnaL" },
            { "Bouvet Island (Bouvetoya)", ")ayotevuoB( dnalsI tevuoB" },
            { "Handcrafted Frozen Hat", "taH nezorF detfarcdnaH" },
            { "Future-proofed", "defoorp-erutuF" },
            { "Grenada", "adanerG" },
            { "Tools, Kids \u0026 Home", "emoH \u0026 sdiK ,slooT" },
            { "Ports", "stroP" },
            { "proactive", "evitcaorp" },
            { "Pennsylvania", "ainavlysnneP" },
            { "Convertible Marks", "skraM elbitrevnoC" },
            { "Awesome Plastic Pants", "stnaP citsalP emosewA" },
            { "projection", "noitcejorp" },
            { "Games, Clothing \u0026 Industrial", "lairtsudnI \u0026 gnihtolC ,semaG" },
            { "Djibouti Franc", "cnarF ituobijD" },
            { "Generic Steel Pizza", "azziP leetS cireneG" },
            { "Web", "beW" },
            { "Adaptive", "evitpadA" },
            { "Electronics, Toys \u0026 Garden", "nedraG \u0026 syoT ,scinortcelE" },
            { "Refined Granite Sausages", "segasuaS etinarG denifeR" },
            { "South Africa", "acirfA htuoS" },
            { "parse", "esrap" },
            { "Handmade Concrete Bike", "ekiB etercnoC edamdnaH" },
            { "Practical Plastic Cheese", "eseehC citsalP lacitcarP" },
            { "Somoni", "inomoS" },
            { "Valleys", "syellaV" },
            { "Bahamian Dollar", "ralloD naimahaB" },
            { "Awesome Wooden Bike", "ekiB nedooW emosewA" },
            { "Generic Frozen Hat", "taH nezorF cireneG" },
            { "Re-contextualized", "dezilautxetnoc-eR" },
            { "Martinique", "euqinitraM" },
            { "bypass", "ssapyb" },
            { "Tasty Fresh Chips", "spihC hserF ytsaT" },
            { "Mexican Peso", "oseP nacixeM" },
            { "Kyat", "tayK" },
            { "Alabama", "amabalA" },
            { "Crossing", "gnissorC" },
            { "Generic Rubber Keyboard", "draobyeK rebbuR cireneG" },
            { "Intelligent Soft Sausages", "segasuaS tfoS tnegilletnI" },
            { "Jewelery, Games \u0026 Music", "cisuM \u0026 semaG ,yreleweJ" },
            { "Puerto Rico", "ociR otreuP" },
            { "Open-architected", "detcetihcra-nepO" },
            { "Croatian Kuna", "anuK naitaorC" },
            { "Beauty \u0026 Computers", "sretupmoC \u0026 ytuaeB" },
            { "Incredible", "elbidercnI" },
            { "Virginia", "ainigriV" },
            { "Saint Helena", "aneleH tniaS" },
            { "Virgin Islands, U.S.", ".S.U ,sdnalsI nigriV" },
            { "Persevering", "gnirevesreP" },
            { "Rustic Frozen Computer", "retupmoC nezorF citsuR" },
            { "Refined Concrete Tuna", "anuT etercnoC denifeR" },
            { "homogeneous", "suoenegomoh" },
            { "real-time", "emit-laer" },
            { "New Jersey", "yesreJ weN" },
            { "dot-com", "moc-tod" },
            { "Ohio", "oihO" },
            { "FTP", "PTF" },
            { "Unbranded Granite Towels", "slewoT etinarG dednarbnU" },
            { "innovate", "etavonni" },
            { "Awesome Cotton Chicken", "nekcihC nottoC emosewA" },
            { "United States Minor Outlying Islands", "sdnalsI gniyltuO roniM setatS detinU" },
            { "Plain", "nialP" },
            { "Terrace", "ecarreT" },
            { "redundant", "tnadnuder" },
            { "Function-based", "desab-noitcnuF" },
            { "Toys", "syoT" },
            { "rich", "hcir" },
            { "sensor", "rosnes" },
            { "connecting", "gnitcennoc" },
            { "networks", "skrowten" },
            { "Configuration", "noitarugifnoC" },
            { "Proactive", "evitcaorP" },
            { "solutions", "snoitulos" },
            { "Handmade Steel Fish", "hsiF leetS edamdnaH" },
            { "Tasty Steel Chicken", "nekcihC leetS ytsaT" },
            { "Highway", "yawhgiH" },
            { "integrate", "etargetni" },
            { "RAM", "MAR" },
            { "Practical Concrete Shoes", "seohS etercnoC lacitcarP" },
            { "Health, Music \u0026 Beauty", "ytuaeB \u0026 cisuM ,htlaeH" },
            { "users", "sresu" },
            { "Flats", "stalF" },
            { "robust", "tsubor" },
            { "Pass", "ssaP" },
            { "mobile", "elibom" },
            { "non-volatile", "elitalov-non" },
            { "auxiliary", "yrailixua" }
        };

        [Benchmark(Baseline = true)]
        [Arguments("sensor")]
        public string GetFromMap(string value)
        {
            return _map[value];
        }

        [Benchmark]
        [Arguments("sensor")]
        public string GetFromSwitch(string value)
        {
            return value switch
            {
                "deposit" => "tisoped",
                "invoice" => "eciovni",
                "Sleek" => "keelS",
                "Unbranded Granite Mouse" => "esuoM etinarG dednarbnU",
                "Michigan" => "nagihciM",
                "secondary" => "yradnoces",
                "reboot" => "toober",
                "Outdoors" => "sroodtuO",
                "Cliff" => "ffilC",
                "ivory" => "yrovi",
                "partnerships" => "spihsrentrap",
                "Home Loan Account" => "tnuoccA naoL emoH",
                "Cambridgeshire" => "erihsegdirbmaC",
                "redefine" => "enifeder",
                "Kyrgyz Republic" => "cilbupeR zygryK",
                "Analyst" => "tsylanA",
                "Ameliorated" => "detaroilemA",
                "New Mexico" => "ocixeM weN",
                "monetize" => "ezitenom",
                "circuit" => "tiucric",
                "Fresh" => "hserF",
                "Ergonomic Rubber Keyboard" => "draobyeK rebbuR cimonogrE",
                "Garden" => "nedraG",
                "Human" => "namuH",
                "RSS" => "SSR",
                "morph" => "hprom",
                "Intranet" => "tenartnI",
                "Rustic" => "citsuR",
                "Assimilated" => "detalimissA",
                "Response" => "esnopseR",
                "internet solution" => "noitulos tenretni",
                "XML" => "LMX",
                "Mountain" => "niatnuoM",
                "encompassing" => "gnissapmocne",
                "multimedia" => "aidemitlum",
                "Washington" => "notgnihsaW",
                "Walk" => "klaW",
                "transparent" => "tnerapsnart",
                "Rubber" => "rebbuR",
                "Steel" => "leetS",
                "synthesizing" => "gnizisehtnys",
                "Shores" => "serohS",
                "SAS" => "SAS",
                "Right-sized" => "dezis-thgiR",
                "modular" => "raludom",
                "Soft" => "tfoS",
                "Regional" => "lanoigeR",
                "Re-engineered" => "dereenigne-eR",
                "Codes specifically reserved for testing purposes" =>
                    "sesoprup gnitset rof devreser yllacificeps sedoC",
                "Principal" => "lapicnirP",
                "Expanded" => "dednapxE",
                "Orchestrator" => "rotartsehcrO",
                "e-services" => "secivres-e",
                "black" => "kcalb",
                "Belarussian Ruble" => "elbuR naissuraleB",
                "virtual" => "lautriv",
                "Latvian Lats" => "staL naivtaL",
                "input" => "tupni",
                "Turkish Lira" => "ariL hsikruT",
                "Sudanese Pound" => "dnuoP esenaduS",
                "Iceland Krona" => "anorK dnalecI",
                "Falkland Islands Pound" => "dnuoP sdnalsI dnalklaF",
                "Planner" => "rennalP",
                "primary" => "yramirp",
                "Handmade Concrete Shoes" => "seohS etercnoC edamdnaH",
                "Hong Kong" => "gnoK gnoH",
                "copy" => "ypoc",
                "functionalities" => "seitilanoitcnuf",
                "Bridge" => "egdirB",
                "Communications" => "snoitacinummoC",
                "bandwidth-monitored" => "derotinom-htdiwdnab",
                "calculating" => "gnitaluclac",
                "Representative" => "evitatneserpeR",
                "asynchronous" => "suonorhcnysa",
                "intangible" => "elbignatni",
                "Direct" => "tceriD",
                "seamless" => "sselmaes",
                "Place" => "ecalP",
                "Ergonomic" => "cimonogrE",
                "Generic Frozen Gloves" => "sevolG nezorF cireneG",
                "Sri Lanka Rupee" => "eepuR aknaL irS",
                "extend" => "dnetxe",
                "Programmable" => "elbammargorP",
                "synthesize" => "ezisehtnys",
                "Club" => "bulC",
                "Facilitator" => "rotatilicaF",
                "bandwidth" => "htdiwdnab",
                "Wooden" => "nedooW",
                "Dale" => "elaD",
                "silver" => "revlis",
                "hacking" => "gnikcah",
                "Wyoming" => "gnimoyW",
                "Kansas" => "sasnaK",
                "Internal" => "lanretnI",
                "North Dakota" => "atokaD htroN",
                "Awesome Steel Hat" => "taH leetS emosewA",
                "Mississippi" => "ippississiM",
                "HDD" => "DDH",
                "bus" => "sub",
                "Refined Wooden Table" => "elbaT nedooW denifeR",
                "PCI" => "ICP",
                "recontextualize" => "ezilautxetnocer",
                "Borders" => "sredroB",
                "Enhanced" => "decnahnE",
                "Practical" => "lacitcarP",
                "calculate" => "etaluclac",
                "microchip" => "pihcorcim",
                "Generic" => "cireneG",
                "Wisconsin" => "nisnocsiW",
                "mission-critical" => "lacitirc-noissim",
                "User-centric" => "cirtnec-resU",
                "Designer" => "rengiseD",
                "Concrete" => "etercnoC",
                "parsing" => "gnisrap",
                "Generic Plastic Keyboard" => "draobyeK citsalP cireneG",
                "Practical Cotton Table" => "elbaT nottoC lacitcarP",
                "Profound" => "dnuoforP",
                "Fiji" => "ijiF",
                "Awesome" => "emosewA",
                "secured line" => "enil deruces",
                "alarm" => "mrala",
                "tangible" => "elbignat",
                "models" => "sledom",
                "Auto Loan Account" => "tnuoccA naoL otuA",
                "firewall" => "llawerif",
                "New Hampshire" => "erihspmaH weN",
                "Liaison" => "nosiaiL",
                "Unbranded" => "dednarbnU",
                "Turnpike" => "ekipnruT",
                "Music \u0026 Kids" => "sdiK \u0026 cisuM",
                "yellow" => "wolley",
                "pixel" => "lexip",
                "Frozen" => "nezorF",
                "navigating" => "gnitagivan",
                "Fully-configurable" => "elbarugifnoc-ylluF",
                "brand" => "dnarb",
                "Chief" => "feihC",
                "Republic of Korea" => "aeroK fo cilbupeR",
                "Grocery \u0026 Beauty" => "ytuaeB \u0026 yrecorG",
                "Avon" => "novA",
                "withdrawal" => "lawardhtiw",
                "Fantastic" => "citsatnaF",
                "back-end" => "dne-kcab",
                "Norfolk Island" => "dnalsI klofroN",
                "Guinea Franc" => "cnarF aeniuG",
                "Solutions" => "snoituloS",
                "monitoring" => "gnirotinom",
                "Developer" => "repoleveD",
                "website" => "etisbew",
                "Global" => "labolG",
                "Generic Soft Shirt" => "trihS tfoS cireneG",
                "Credit Card Account" => "tnuoccA draC tiderC",
                "Sleek Plastic Soap" => "paoS citsalP keelS",
                "cutting-edge" => "egde-gnittuc",
                "Dominican Republic" => "cilbupeR nacinimoD",
                "Functionality" => "ytilanoitcnuF",
                "contextually-based" => "desab-yllautxetnoc",
                "Yemen" => "nemeY",
                "generating" => "gnitareneg",
                "PNG" => "GNP",
                "Solomon Islands" => "sdnalsI nomoloS",
                "cultivate" => "etavitluc",
                "Personal Loan Account" => "tnuoccA naoL lanosreP",
                "Research" => "hcraeseR",
                "Bedfordshire" => "erihsdrofdeB",
                "Paradigm" => "mgidaraP",
                "Directives" => "sevitceriD",
                "online" => "enilno",
                "Granite" => "etinarG",
                "Seychelles Rupee" => "eepuR sellehcyeS",
                "Circle" => "elcriC",
                "Underpass" => "ssaprednU",
                "Tugrik" => "kirguT",
                "matrix" => "xirtam",
                "bifurcated" => "detacrufib",
                "Savings Account" => "tnuoccA sgnivaS",
                "incentivize" => "ezivitnecni",
                "Vision-oriented" => "detneiro-noisiV",
                "compelling" => "gnillepmoc",
                "Hawaii" => "iiawaH",
                "Handcrafted Wooden Cheese" => "eseehC nedooW detfarcdnaH",
                "Program" => "margorP",
                "Gold" => "dloG",
                "Up-sized" => "dezis-pU",
                "Tokelau" => "ualekoT",
                "payment" => "tnemyap",
                "lavender" => "redneval",
                "Trace" => "ecarT",
                "Licensed Plastic Keyboard" => "draobyeK citsalP desneciL",
                "Pike" => "ekiP",
                "Refined" => "denifeR",
                "Quality-focused" => "desucof-ytilauQ",
                "grow" => "worg",
                "Ecuador" => "rodaucE",
                "HTTP" => "PTTH",
                "Music, Tools \u0026 Automotive" => "evitomotuA \u0026 slooT ,cisuM",
                "Creative" => "evitaerC",
                "hard drive" => "evird drah",
                "transmit" => "timsnart",
                "syndicate" => "etacidnys",
                "Yuan Renminbi" => "ibnimneR nauY",
                "Horizontal" => "latnoziroH",
                "Garden \u0026 Automotive" => "evitomotuA \u0026 nedraG",
                "bluetooth" => "htooteulb",
                "Mauritius" => "suitiruaM",
                "Fantastic Cotton Fish" => "hsiF nottoC citsatnaF",
                "Barbados" => "sodabraB",
                "value-added" => "dedda-eulav",
                "Silver" => "revliS",
                "B2B" => "B2B",
                "Kwanza" => "aznawK",
                "Union" => "noinU",
                "Strategist" => "tsigetartS",
                "engage" => "egagne",
                "synergistic" => "citsigrenys",
                "seize" => "ezies",
                "cross-platform" => "mroftalp-ssorc",
                "Small Wooden Chicken" => "nekcihC nedooW llamS",
                "Israel" => "learsI",
                "Berkshire" => "erihskreB",
                "Kids, Garden \u0026 Kids" => "sdiK \u0026 nedraG ,sdiK",
                "leading-edge" => "egde-gnidael",
                "Gibraltar Pound" => "dnuoP ratlarbiG",
                "interface" => "ecafretni",
                "transition" => "noitisnart",
                "4th generation" => "noitareneg ht4",
                "index" => "xedni",
                "Arkansas" => "sasnakrA",
                "multi-tasking" => "gniksat-itlum",
                "end-to-end" => "dne-ot-dne",
                "application" => "noitacilppa",
                "programming" => "gnimmargorp",
                "access" => "ssecca",
                "Awesome Granite Pizza" => "azziP etinarG emosewA",
                "Intelligent Concrete Table" => "elbaT etercnoC tnegilletnI",
                "front-end" => "dne-tnorf",
                "Fields" => "sdleiF",
                "Clothing" => "gnihtolC",
                "green" => "neerg",
                "Buckinghamshire" => "erihsmahgnikcuB",
                "Shoal" => "laohS",
                "Handmade Rubber Car" => "raC rebbuR edamdnaH",
                "bricks-and-clicks" => "skcilc-dna-skcirb",
                "experiences" => "secneirepxe",
                "revolutionary" => "yranoitulover",
                "systems" => "smetsys",
                "Rapids" => "sdipaR",
                "JSON" => "NOSJ",
                "South Carolina" => "aniloraC htuoS",
                "Intelligent" => "tnegilletnI",
                "Ergonomic Fresh Shoes" => "seohS hserF cimonogrE",
                "Kenyan Shilling" => "gnillihS nayneK",
                "Nuevo Sol" => "loS oveuN",
                "Cliffs" => "sffilC",
                "reintermediate" => "etaidemretnier",
                "Overpass" => "ssaprevO",
                "Camp" => "pmaC",
                "Maryland" => "dnalyraM",
                "grey" => "yerg",
                "Sleek Frozen Ball" => "llaB nezorF keelS",
                "Dominica" => "acinimoD",
                "human-resource" => "ecruoser-namuh",
                "Shoes" => "seohS",
                "framework" => "krowemarf",
                "Corporate" => "etaroproC",
                "Points" => "stnioP",
                "Maine" => "eniaM",
                "Ergonomic Steel Ball" => "llaB leetS cimonogrE",
                "Multi-channelled" => "dellennahc-itluM",
                "program" => "margorp",
                "engineer" => "reenigne",
                "THX" => "XHT",
                "Licensed Metal Car" => "raC lateM desneciL",
                "24/7" => "7/42",
                "concept" => "tpecnoc",
                "deliverables" => "selbareviled",
                "Netherlands Antilles" => "sellitnA sdnalrehteN",
                "Fantastic Granite Keyboard" => "draobyeK etinarG citsatnaF",
                "teal" => "laet",
                "24/365" => "563/42",
                "interactive" => "evitcaretni",
                "back up" => "pu kcab",
                "Square" => "erauqS",
                "neural" => "laruen",
                "Kids \u0026 Home" => "emoH \u0026 sdiK",
                "Automotive \u0026 Music" => "cisuM \u0026 evitomotuA",
                "sky blue" => "eulb yks",
                "Ramp" => "pmaR",
                "pricing structure" => "erutcurts gnicirp",
                "Bermuda" => "adumreB",
                "methodology" => "ygolodohtem",
                "Falls" => "sllaF",
                "Mission" => "noissiM",
                "interfaces" => "secafretni",
                "USB" => "BSU",
                "Plastic" => "citsalP",
                "Handcrafted Soft Chips" => "spihC tfoS detfarcdnaH",
                "El Salvador" => "rodavlaS lE",
                "Digitized" => "dezitigiD",
                "Reunion" => "noinueR",
                "Pre-emptive" => "evitpme-erP",
                "Assistant" => "tnatsissA",
                "Interactions" => "snoitcaretnI",
                "GB" => "BG",
                "South Dakota" => "atokaD htuoS",
                "Canyon" => "noynaC",
                "Guadeloupe" => "epuoledauG",
                "Intuitive" => "evitiutnI",
                "Small Soft Bacon" => "nocaB tfoS llamS",
                "copying" => "gniypoc",
                "Tasty Steel Chips" => "spihC leetS ytsaT",
                "Fantastic Metal Sausages" => "segasuaS lateM citsatnaF",
                "Generic Plastic Soap" => "paoS citsalP cireneG",
                "protocol" => "locotorp",
                "relationships" => "spihsnoitaler",
                "maroon" => "nooram",
                "capacitor" => "roticapac",
                "Specialist" => "tsilaicepS",
                "Officer" => "reciffO",
                "AGP" => "PGA",
                "Supervisor" => "rosivrepuS",
                "Assurance" => "ecnarussA",
                "Customer" => "remotsuC",
                "Money Market Account" => "tnuoccA tekraM yenoM",
                "architectures" => "serutcetihcra",
                "magenta" => "atnegam",
                "markets" => "stekram",
                "array" => "yarra",
                "Branding" => "gnidnarB",
                "Central" => "lartneC",
                "regional" => "lanoiger",
                "Graphic Interface" => "ecafretnI cihparG",
                "Road" => "daoR",
                "hardware" => "erawdrah",
                "system" => "metsys",
                "Jordan" => "nadroJ",
                "intuitive" => "evitiutni",
                "Consultant" => "tnatlusnoC",
                "New York" => "kroY weN",
                "Dobra" => "arboD",
                "compress" => "sserpmoc",
                "Norwegian Krone" => "enorK naigewroN",
                "supply-chains" => "sniahc-ylppus",
                "Generic Plastic Gloves" => "sevolG citsalP cireneG",
                "fuchsia" => "aishcuf",
                "Optimization" => "noitazimitpO",
                "Data" => "ataD",
                "Lithuanian Litas" => "satiL nainauhtiL",
                "enterprise" => "esirpretne",
                "action-items" => "smeti-noitca",
                "Sleek Steel Shoes" => "seohS leetS keelS",
                "Metal" => "lateM",
                "Uganda Shilling" => "gnillihS adnagU",
                "International" => "lanoitanretnI",
                "Tools" => "slooT",
                "Computers, Beauty \u0026 Health" => "htlaeH \u0026 ytuaeB ,sretupmoC",
                "Engineer" => "reenignE",
                "Movies, Home \u0026 Automotive" => "evitomotuA \u0026 emoH ,seivoM",
                "Dynamic" => "cimanyD",
                "Incredible Rubber Tuna" => "anuT rebbuR elbidercnI",
                "digital" => "latigid",
                "Canada" => "adanaC",
                "Trail" => "liarT",
                "Gorgeous" => "suoegroG",
                "Licensed Metal Tuna" => "anuT lateM desneciL",
                "Sports \u0026 Baby" => "ybaB \u0026 stropS",
                "Legacy" => "ycageL",
                "Industrial \u0026 Automotive" => "evitomotuA \u0026 lairtsudnI",
                "open-source" => "ecruos-nepo",
                "next-generation" => "noitareneg-txen",
                "transform" => "mrofsnart",
                "JBOD" => "DOBJ",
                "well-modulated" => "detaludom-llew",
                "Checking Account" => "tnuoccA gnikcehC",
                "Kids" => "sdiK",
                "Investor" => "rotsevnI",
                "frictionless" => "sselnoitcirf",
                "overriding" => "gnidirrevo",
                "customized" => "dezimotsuc",
                "SCSI" => "ISCS",
                "Groves" => "sevorG",
                "Isle" => "elsI",
                "backing up" => "pu gnikcab",
                "Platinum" => "munitalP",
                "card" => "drac",
                "Toys \u0026 Sports" => "stropS \u0026 syoT",
                "Small Granite Bike" => "ekiB etinarG llamS",
                "open architecture" => "erutcetihcra nepo",
                "Open-source" => "ecruos-nepO",
                "Handmade Frozen Pizza" => "azziP nezorF edamdnaH",
                "quantifying" => "gniyfitnauq",
                "El Salvador Colon" => "noloC rodavlaS lE",
                "Texas" => "saxeT",
                "azure" => "eruza",
                "Executive" => "evitucexE",
                "Corner" => "renroC",
                "integrated" => "detargetni",
                "wireless" => "sseleriw",
                "challenge" => "egnellahc",
                "hack" => "kcah",
                "Utah" => "hatU",
                "Home, Electronics \u0026 Jewelery" => "yreleweJ \u0026 scinortcelE ,emoH",
                "Illinois" => "sionillI",
                "Ergonomic Wooden Tuna" => "anuT nedooW cimonogrE",
                "Refined Steel Table" => "elbaT leetS denifeR",
                "approach" => "hcaorppa",
                "haptic" => "citpah",
                "European Unit of Account 9(E.U.A.-9)" => ")9-.A.U.E(9 tnuoccA fo tinU naeporuE",
                "Tasty" => "ytsaT",
                "Managed" => "deganaM",
                "Investment Account" => "tnuoccA tnemtsevnI",
                "Idaho" => "ohadI",
                "SDD" => "DDS",
                "Plaza" => "azalP",
                "deliver" => "reviled",
                "Unbranded Plastic Gloves" => "sevolG citsalP dednarbnU",
                "optimize" => "ezimitpo",
                "Via" => "aiV",
                "gold" => "dlog",
                "Path" => "htaP",
                "Gorgeous Frozen Salad" => "dalaS nezorF suoegroG",
                "violet" => "teloiv",
                "Small" => "llamS",
                "Bermudian Dollar (customarily known as Bermuda Dollar)" =>
                    ")ralloD adumreB sa nwonk yliramotsuc( ralloD naidumreB",
                "Way" => "yaW",
                "enhance" => "ecnahne",
                "architect" => "tcetihcra",
                "Shoes \u0026 Garden" => "nedraG \u0026 seohS",
                "Meadow" => "wodaeM",
                "transmitting" => "gnittimsnart",
                "Cotton" => "nottoC",
                "Hollow" => "wolloH",
                "applications" => "snoitacilppa",
                "Street" => "teertS",
                "Kentucky" => "ykcutneK",
                "Hills" => "slliH",
                "impactful" => "luftcapmi",
                "New Caledonia" => "ainodelaC weN",
                "Ridge" => "egdiR",
                "purple" => "elprup",
                "Marketing" => "gnitekraM",
                "Norway" => "yawroN",
                "Tasty Wooden Sausages" => "segasuaS nedooW ytsaT",
                "Agent" => "tnegA",
                "Accountability" => "ytilibatnuoccA",
                "Sleek Rubber Towels" => "slewoT rebbuR keelS",
                "Cordoba Oro" => "orO abodroC",
                "encoding" => "gnidocne",
                "Division" => "noisiviD",
                "District" => "tcirtsiD",
                "user-centric" => "cirtnec-resu",
                "Practical Concrete Ball" => "llaB etercnoC lacitcarP",
                "multi-byte" => "etyb-itlum",
                "IB" => "BI",
                "Uganda" => "adnagU",
                "unleash" => "hsaelnu",
                "Handcrafted Soft Keyboard" => "draobyeK tfoS detfarcdnaH",
                "Shore" => "erohS",
                "Director" => "rotceriD",
                "architecture" => "erutcetihcra",
                "Mozambique" => "euqibmazoM",
                "explicit" => "ticilpxe",
                "infrastructures" => "serutcurtsarfni",
                "Bond Markets Units European Composite Unit (EURCO)" =>
                    ")OCRUE( tinU etisopmoC naeporuE stinU stekraM dnoB",
                "Keys" => "syeK",
                "e-markets" => "stekram-e",
                "Business-focused" => "desucof-ssenisuB",
                "Small Frozen Hat" => "taH nezorF llamS",
                "Rustic Wooden Sausages" => "segasuaS nedooW citsuR",
                "plug-and-play" => "yalp-dna-gulp",
                "visualize" => "ezilausiv",
                "Licensed Concrete Computer" => "retupmoC etercnoC desneciL",
                "Burgs" => "sgruB",
                "Versatile" => "elitasreV",
                "Practical Rubber Chicken" => "nekcihC rebbuR lacitcarP",
                "Generic Granite Ball" => "llaB etinarG cireneG",
                "bleeding-edge" => "egde-gnideelb",
                "Locks" => "skcoL",
                "orchid" => "dihcro",
                "Handmade Steel Keyboard" => "draobyeK leetS edamdnaH",
                "Product" => "tcudorP",
                "Nevada" => "adaveN",
                "Synergized" => "dezigrenyS",
                "indexing" => "gnixedni",
                "plum" => "mulp",
                "Baby" => "ybaB",
                "Skyway" => "yawykS",
                "Junction" => "noitcnuJ",
                "Ergonomic Fresh Gloves" => "sevolG hserF cimonogrE",
                "portals" => "slatrop",
                "capability" => "ytilibapac",
                "Intelligent Cotton Soap" => "paoS nottoC tnegilletnI",
                "strategize" => "ezigetarts",
                "Electronics" => "scinortcelE",
                "Awesome Fresh Chicken" => "nekcihC hserF emosewA",
                "Passage" => "egassaP",
                "orange" => "egnaro",
                "Malawi" => "iwalaM",
                "exuding" => "gniduxe",
                "Technician" => "naicinhceT",
                "View" => "weiV",
                "Intelligent Plastic Salad" => "dalaS citsalP tnegilletnI",
                "Montana" => "anatnoM",
                "uniform" => "mrofinu",
                "Lebanese Pound" => "dnuoP esenabeL",
                "Indiana" => "anaidnI",
                "optical" => "lacitpo",
                "Incredible Concrete Bike" => "ekiB etercnoC elbidercnI",
                "Saudi Riyal" => "layiR iduaS",
                "generate" => "etareneg",
                "Moldova" => "avodloM",
                "driver" => "revird",
                "Swiss Franc" => "cnarF ssiwS",
                "Mobility" => "ytiliboM",
                "Guinea" => "aeniuG",
                "ability" => "ytiliba",
                "Curve" => "evruC",
                "Flat" => "talF",
                "transmitter" => "rettimsnart",
                "Outdoors, Clothing \u0026 Games" => "semaG \u0026 gnihtolC ,sroodtuO",
                "Health, Movies \u0026 Books" => "skooB \u0026 seivoM ,htlaeH",
                "Mountains" => "sniatnuoM",
                "Identity" => "ytitnedI",
                "budgetary management" => "tnemeganam yrategdub",
                "Isle of Man" => "naM fo elsI",
                "full-range" => "egnar-lluf",
                "directional" => "lanoitcerid",
                "SQL" => "LQS",
                "Configurable" => "elbarugifnoC",
                "Awesome Rubber Chicken" => "nekcihC rebbuR emosewA",
                "Group" => "puorG",
                "Island" => "dnalsI",
                "Handmade Fresh Hat" => "taH hserF edamdnaH",
                "Guarani" => "inarauG",
                "harness" => "ssenrah",
                "Usability" => "ytilibasU",
                "override" => "edirrevo",
                "heuristic" => "citsirueh",
                "Uruguay" => "yaugurU",
                "Handmade" => "edamdnaH",
                "global" => "labolg",
                "Fantastic Soft Shirt" => "trihS tfoS citsatnaF",
                "solid state" => "etats dilos",
                "Roads" => "sdaoR",
                "bypassing" => "gnissapyb",
                "Station" => "noitatS",
                "Licensed Fresh Pizza" => "azziP hserF desneciL",
                "blockchains" => "sniahckcolb",
                "Land" => "dnaL",
                "Bouvet Island (Bouvetoya)" => ")ayotevuoB( dnalsI tevuoB",
                "Handcrafted Frozen Hat" => "taH nezorF detfarcdnaH",
                "Future-proofed" => "defoorp-erutuF",
                "Grenada" => "adanerG",
                "Tools, Kids \u0026 Home" => "emoH \u0026 sdiK ,slooT",
                "Ports" => "stroP",
                "proactive" => "evitcaorp",
                "Pennsylvania" => "ainavlysnneP",
                "Convertible Marks" => "skraM elbitrevnoC",
                "Awesome Plastic Pants" => "stnaP citsalP emosewA",
                "projection" => "noitcejorp",
                "Games, Clothing \u0026 Industrial" => "lairtsudnI \u0026 gnihtolC ,semaG",
                "Djibouti Franc" => "cnarF ituobijD",
                "Generic Steel Pizza" => "azziP leetS cireneG",
                "Web" => "beW",
                "Adaptive" => "evitpadA",
                "Electronics, Toys \u0026 Garden" => "nedraG \u0026 syoT ,scinortcelE",
                "Refined Granite Sausages" => "segasuaS etinarG denifeR",
                "South Africa" => "acirfA htuoS",
                "parse" => "esrap",
                "Handmade Concrete Bike" => "ekiB etercnoC edamdnaH",
                "Practical Plastic Cheese" => "eseehC citsalP lacitcarP",
                "Somoni" => "inomoS",
                "Valleys" => "syellaV",
                "Bahamian Dollar" => "ralloD naimahaB",
                "Awesome Wooden Bike" => "ekiB nedooW emosewA",
                "Generic Frozen Hat" => "taH nezorF cireneG",
                "Re-contextualized" => "dezilautxetnoc-eR",
                "Martinique" => "euqinitraM",
                "bypass" => "ssapyb",
                "Tasty Fresh Chips" => "spihC hserF ytsaT",
                "Mexican Peso" => "oseP nacixeM",
                "Kyat" => "tayK",
                "Alabama" => "amabalA",
                "Crossing" => "gnissorC",
                "Generic Rubber Keyboard" => "draobyeK rebbuR cireneG",
                "Intelligent Soft Sausages" => "segasuaS tfoS tnegilletnI",
                "Jewelery, Games \u0026 Music" => "cisuM \u0026 semaG ,yreleweJ",
                "Puerto Rico" => "ociR otreuP",
                "Open-architected" => "detcetihcra-nepO",
                "Croatian Kuna" => "anuK naitaorC",
                "Beauty \u0026 Computers" => "sretupmoC \u0026 ytuaeB",
                "Incredible" => "elbidercnI",
                "Virginia" => "ainigriV",
                "Saint Helena" => "aneleH tniaS",
                "Virgin Islands, U.S." => ".S.U ,sdnalsI nigriV",
                "Persevering" => "gnirevesreP",
                "Rustic Frozen Computer" => "retupmoC nezorF citsuR",
                "Refined Concrete Tuna" => "anuT etercnoC denifeR",
                "homogeneous" => "suoenegomoh",
                "real-time" => "emit-laer",
                "New Jersey" => "yesreJ weN",
                "dot-com" => "moc-tod",
                "Ohio" => "oihO",
                "FTP" => "PTF",
                "Unbranded Granite Towels" => "slewoT etinarG dednarbnU",
                "innovate" => "etavonni",
                "Awesome Cotton Chicken" => "nekcihC nottoC emosewA",
                "United States Minor Outlying Islands" => "sdnalsI gniyltuO roniM setatS detinU",
                "Plain" => "nialP",
                "Terrace" => "ecarreT",
                "redundant" => "tnadnuder",
                "Function-based" => "desab-noitcnuF",
                "Toys" => "syoT",
                "rich" => "hcir",
                "sensor" => "rosnes",
                "connecting" => "gnitcennoc",
                "networks" => "skrowten",
                "Configuration" => "noitarugifnoC",
                "Proactive" => "evitcaorP",
                "solutions" => "snoitulos",
                "Handmade Steel Fish" => "hsiF leetS edamdnaH",
                "Tasty Steel Chicken" => "nekcihC leetS ytsaT",
                "Highway" => "yawhgiH",
                "integrate" => "etargetni",
                "RAM" => "MAR",
                "Practical Concrete Shoes" => "seohS etercnoC lacitcarP",
                "Health, Music \u0026 Beauty" => "ytuaeB \u0026 cisuM ,htlaeH",
                "users" => "sresu",
                "Flats" => "stalF",
                "robust" => "tsubor",
                "Pass" => "ssaP",
                "mobile" => "elibom",
                "non-volatile" => "elitalov-non",
                "auxiliary" => "yrailixua",
                _ => value
            };
        }

        [Benchmark]
        [Arguments("sensor")]
        public string GetFromSwitchCase(string value)
        {
            switch (value)
            {
                case "deposit": return "tisoped";
                case "invoice": return "eciovni";
                case "Sleek": return "keelS";
                case "Unbranded Granite Mouse": return "esuoM etinarG dednarbnU";
                case "Michigan": return "nagihciM";
                case "secondary": return "yradnoces";
                case "reboot": return "toober";
                case "Outdoors": return "sroodtuO";
                case "Cliff": return "ffilC";
                case "ivory": return "yrovi";
                case "partnerships": return "spihsrentrap";
                case "Home Loan Account": return "tnuoccA naoL emoH";
                case "Cambridgeshire": return "erihsegdirbmaC";
                case "redefine": return "enifeder";
                case "Kyrgyz Republic": return "cilbupeR zygryK";
                case "Analyst": return "tsylanA";
                case "Ameliorated": return "detaroilemA";
                case "New Mexico": return "ocixeM weN";
                case "monetize": return "ezitenom";
                case "circuit": return "tiucric";
                case "Fresh": return "hserF";
                case "Ergonomic Rubber Keyboard": return "draobyeK rebbuR cimonogrE";
                case "Garden": return "nedraG";
                case "Human": return "namuH";
                case "RSS": return "SSR";
                case "morph": return "hprom";
                case "Intranet": return "tenartnI";
                case "Rustic": return "citsuR";
                case "Assimilated": return "detalimissA";
                case "Response": return "esnopseR";
                case "internet solution": return "noitulos tenretni";
                case "XML": return "LMX";
                case "Mountain": return "niatnuoM";
                case "encompassing": return "gnissapmocne";
                case "multimedia": return "aidemitlum";
                case "Washington": return "notgnihsaW";
                case "Walk": return "klaW";
                case "transparent": return "tnerapsnart";
                case "Rubber": return "rebbuR";
                case "Steel": return "leetS";
                case "synthesizing": return "gnizisehtnys";
                case "Shores": return "serohS";
                case "SAS": return "SAS";
                case "Right-sized": return "dezis-thgiR";
                case "modular": return "raludom";
                case "Soft": return "tfoS";
                case "Regional": return "lanoigeR";
                case "Re-engineered": return "dereenigne-eR";
                case "Codes specifically reserved for testing purposes":
                    return "sesoprup gnitset rof devreser yllacificeps sedoC";
                case "Principal": return "lapicnirP";
                case "Expanded": return "dednapxE";
                case "Orchestrator": return "rotartsehcrO";
                case "e-services": return "secivres-e";
                case "black": return "kcalb";
                case "Belarussian Ruble": return "elbuR naissuraleB";
                case "virtual": return "lautriv";
                case "Latvian Lats": return "staL naivtaL";
                case "input": return "tupni";
                case "Turkish Lira": return "ariL hsikruT";
                case "Sudanese Pound": return "dnuoP esenaduS";
                case "Iceland Krona": return "anorK dnalecI";
                case "Falkland Islands Pound": return "dnuoP sdnalsI dnalklaF";
                case "Planner": return "rennalP";
                case "primary": return "yramirp";
                case "Handmade Concrete Shoes": return "seohS etercnoC edamdnaH";
                case "Hong Kong": return "gnoK gnoH";
                case "copy": return "ypoc";
                case "functionalities": return "seitilanoitcnuf";
                case "Bridge": return "egdirB";
                case "Communications": return "snoitacinummoC";
                case "bandwidth-monitored": return "derotinom-htdiwdnab";
                case "calculating": return "gnitaluclac";
                case "Representative": return "evitatneserpeR";
                case "asynchronous": return "suonorhcnysa";
                case "intangible": return "elbignatni";
                case "Direct": return "tceriD";
                case "seamless": return "sselmaes";
                case "Place": return "ecalP";
                case "Ergonomic": return "cimonogrE";
                case "Generic Frozen Gloves": return "sevolG nezorF cireneG";
                case "Sri Lanka Rupee": return "eepuR aknaL irS";
                case "extend": return "dnetxe";
                case "Programmable": return "elbammargorP";
                case "synthesize": return "ezisehtnys";
                case "Club": return "bulC";
                case "Facilitator": return "rotatilicaF";
                case "bandwidth": return "htdiwdnab";
                case "Wooden": return "nedooW";
                case "Dale": return "elaD";
                case "silver": return "revlis";
                case "hacking": return "gnikcah";
                case "Wyoming": return "gnimoyW";
                case "Kansas": return "sasnaK";
                case "Internal": return "lanretnI";
                case "North Dakota": return "atokaD htroN";
                case "Awesome Steel Hat": return "taH leetS emosewA";
                case "Mississippi": return "ippississiM";
                case "HDD": return "DDH";
                case "bus": return "sub";
                case "Refined Wooden Table": return "elbaT nedooW denifeR";
                case "PCI": return "ICP";
                case "recontextualize": return "ezilautxetnocer";
                case "Borders": return "sredroB";
                case "Enhanced": return "decnahnE";
                case "Practical": return "lacitcarP";
                case "calculate": return "etaluclac";
                case "microchip": return "pihcorcim";
                case "Generic": return "cireneG";
                case "Wisconsin": return "nisnocsiW";
                case "mission-critical": return "lacitirc-noissim";
                case "User-centric": return "cirtnec-resU";
                case "Designer": return "rengiseD";
                case "Concrete": return "etercnoC";
                case "parsing": return "gnisrap";
                case "Generic Plastic Keyboard": return "draobyeK citsalP cireneG";
                case "Practical Cotton Table": return "elbaT nottoC lacitcarP";
                case "Profound": return "dnuoforP";
                case "Fiji": return "ijiF";
                case "Awesome": return "emosewA";
                case "secured line": return "enil deruces";
                case "alarm": return "mrala";
                case "tangible": return "elbignat";
                case "models": return "sledom";
                case "Auto Loan Account": return "tnuoccA naoL otuA";
                case "firewall": return "llawerif";
                case "New Hampshire": return "erihspmaH weN";
                case "Liaison": return "nosiaiL";
                case "Unbranded": return "dednarbnU";
                case "Turnpike": return "ekipnruT";
                case "Music \u0026 Kids": return "sdiK \u0026 cisuM";
                case "yellow": return "wolley";
                case "pixel": return "lexip";
                case "Frozen": return "nezorF";
                case "navigating": return "gnitagivan";
                case "Fully-configurable": return "elbarugifnoc-ylluF";
                case "brand": return "dnarb";
                case "Chief": return "feihC";
                case "Republic of Korea": return "aeroK fo cilbupeR";
                case "Grocery \u0026 Beauty": return "ytuaeB \u0026 yrecorG";
                case "Avon": return "novA";
                case "withdrawal": return "lawardhtiw";
                case "Fantastic": return "citsatnaF";
                case "back-end": return "dne-kcab";
                case "Norfolk Island": return "dnalsI klofroN";
                case "Guinea Franc": return "cnarF aeniuG";
                case "Solutions": return "snoituloS";
                case "monitoring": return "gnirotinom";
                case "Developer": return "repoleveD";
                case "website": return "etisbew";
                case "Global": return "labolG";
                case "Generic Soft Shirt": return "trihS tfoS cireneG";
                case "Credit Card Account": return "tnuoccA draC tiderC";
                case "Sleek Plastic Soap": return "paoS citsalP keelS";
                case "cutting-edge": return "egde-gnittuc";
                case "Dominican Republic": return "cilbupeR nacinimoD";
                case "Functionality": return "ytilanoitcnuF";
                case "contextually-based": return "desab-yllautxetnoc";
                case "Yemen": return "nemeY";
                case "generating": return "gnitareneg";
                case "PNG": return "GNP";
                case "Solomon Islands": return "sdnalsI nomoloS";
                case "cultivate": return "etavitluc";
                case "Personal Loan Account": return "tnuoccA naoL lanosreP";
                case "Research": return "hcraeseR";
                case "Bedfordshire": return "erihsdrofdeB";
                case "Paradigm": return "mgidaraP";
                case "Directives": return "sevitceriD";
                case "online": return "enilno";
                case "Granite": return "etinarG";
                case "Seychelles Rupee": return "eepuR sellehcyeS";
                case "Circle": return "elcriC";
                case "Underpass": return "ssaprednU";
                case "Tugrik": return "kirguT";
                case "matrix": return "xirtam";
                case "bifurcated": return "detacrufib";
                case "Savings Account": return "tnuoccA sgnivaS";
                case "incentivize": return "ezivitnecni";
                case "Vision-oriented": return "detneiro-noisiV";
                case "compelling": return "gnillepmoc";
                case "Hawaii": return "iiawaH";
                case "Handcrafted Wooden Cheese": return "eseehC nedooW detfarcdnaH";
                case "Program": return "margorP";
                case "Gold": return "dloG";
                case "Up-sized": return "dezis-pU";
                case "Tokelau": return "ualekoT";
                case "payment": return "tnemyap";
                case "lavender": return "redneval";
                case "Trace": return "ecarT";
                case "Licensed Plastic Keyboard": return "draobyeK citsalP desneciL";
                case "Pike": return "ekiP";
                case "Refined": return "denifeR";
                case "Quality-focused": return "desucof-ytilauQ";
                case "grow": return "worg";
                case "Ecuador": return "rodaucE";
                case "HTTP": return "PTTH";
                case "Music, Tools \u0026 Automotive": return "evitomotuA \u0026 slooT ,cisuM";
                case "Creative": return "evitaerC";
                case "hard drive": return "evird drah";
                case "transmit": return "timsnart";
                case "syndicate": return "etacidnys";
                case "Yuan Renminbi": return "ibnimneR nauY";
                case "Horizontal": return "latnoziroH";
                case "Garden \u0026 Automotive": return "evitomotuA \u0026 nedraG";
                case "bluetooth": return "htooteulb";
                case "Mauritius": return "suitiruaM";
                case "Fantastic Cotton Fish": return "hsiF nottoC citsatnaF";
                case "Barbados": return "sodabraB";
                case "value-added": return "dedda-eulav";
                case "Silver": return "revliS";
                case "B2B": return "B2B";
                case "Kwanza": return "aznawK";
                case "Union": return "noinU";
                case "Strategist": return "tsigetartS";
                case "engage": return "egagne";
                case "synergistic": return "citsigrenys";
                case "seize": return "ezies";
                case "cross-platform": return "mroftalp-ssorc";
                case "Small Wooden Chicken": return "nekcihC nedooW llamS";
                case "Israel": return "learsI";
                case "Berkshire": return "erihskreB";
                case "Kids, Garden \u0026 Kids": return "sdiK \u0026 nedraG ,sdiK";
                case "leading-edge": return "egde-gnidael";
                case "Gibraltar Pound": return "dnuoP ratlarbiG";
                case "interface": return "ecafretni";
                case "transition": return "noitisnart";
                case "4th generation": return "noitareneg ht4";
                case "index": return "xedni";
                case "Arkansas": return "sasnakrA";
                case "multi-tasking": return "gniksat-itlum";
                case "end-to-end": return "dne-ot-dne";
                case "application": return "noitacilppa";
                case "programming": return "gnimmargorp";
                case "access": return "ssecca";
                case "Awesome Granite Pizza": return "azziP etinarG emosewA";
                case "Intelligent Concrete Table": return "elbaT etercnoC tnegilletnI";
                case "front-end": return "dne-tnorf";
                case "Fields": return "sdleiF";
                case "Clothing": return "gnihtolC";
                case "green": return "neerg";
                case "Buckinghamshire": return "erihsmahgnikcuB";
                case "Shoal": return "laohS";
                case "Handmade Rubber Car": return "raC rebbuR edamdnaH";
                case "bricks-and-clicks": return "skcilc-dna-skcirb";
                case "experiences": return "secneirepxe";
                case "revolutionary": return "yranoitulover";
                case "systems": return "smetsys";
                case "Rapids": return "sdipaR";
                case "JSON": return "NOSJ";
                case "South Carolina": return "aniloraC htuoS";
                case "Intelligent": return "tnegilletnI";
                case "Ergonomic Fresh Shoes": return "seohS hserF cimonogrE";
                case "Kenyan Shilling": return "gnillihS nayneK";
                case "Nuevo Sol": return "loS oveuN";
                case "Cliffs": return "sffilC";
                case "reintermediate": return "etaidemretnier";
                case "Overpass": return "ssaprevO";
                case "Camp": return "pmaC";
                case "Maryland": return "dnalyraM";
                case "grey": return "yerg";
                case "Sleek Frozen Ball": return "llaB nezorF keelS";
                case "Dominica": return "acinimoD";
                case "human-resource": return "ecruoser-namuh";
                case "Shoes": return "seohS";
                case "framework": return "krowemarf";
                case "Corporate": return "etaroproC";
                case "Points": return "stnioP";
                case "Maine": return "eniaM";
                case "Ergonomic Steel Ball": return "llaB leetS cimonogrE";
                case "Multi-channelled": return "dellennahc-itluM";
                case "program": return "margorp";
                case "engineer": return "reenigne";
                case "THX": return "XHT";
                case "Licensed Metal Car": return "raC lateM desneciL";
                case "24/7": return "7/42";
                case "concept": return "tpecnoc";
                case "deliverables": return "selbareviled";
                case "Netherlands Antilles": return "sellitnA sdnalrehteN";
                case "Fantastic Granite Keyboard": return "draobyeK etinarG citsatnaF";
                case "teal": return "laet";
                case "24/365": return "563/42";
                case "interactive": return "evitcaretni";
                case "back up": return "pu kcab";
                case "Square": return "erauqS";
                case "neural": return "laruen";
                case "Kids \u0026 Home": return "emoH \u0026 sdiK";
                case "Automotive \u0026 Music": return "cisuM \u0026 evitomotuA";
                case "sky blue": return "eulb yks";
                case "Ramp": return "pmaR";
                case "pricing structure": return "erutcurts gnicirp";
                case "Bermuda": return "adumreB";
                case "methodology": return "ygolodohtem";
                case "Falls": return "sllaF";
                case "Mission": return "noissiM";
                case "interfaces": return "secafretni";
                case "USB": return "BSU";
                case "Plastic": return "citsalP";
                case "Handcrafted Soft Chips": return "spihC tfoS detfarcdnaH";
                case "El Salvador": return "rodavlaS lE";
                case "Digitized": return "dezitigiD";
                case "Reunion": return "noinueR";
                case "Pre-emptive": return "evitpme-erP";
                case "Assistant": return "tnatsissA";
                case "Interactions": return "snoitcaretnI";
                case "GB": return "BG";
                case "South Dakota": return "atokaD htuoS";
                case "Canyon": return "noynaC";
                case "Guadeloupe": return "epuoledauG";
                case "Intuitive": return "evitiutnI";
                case "Small Soft Bacon": return "nocaB tfoS llamS";
                case "copying": return "gniypoc";
                case "Tasty Steel Chips": return "spihC leetS ytsaT";
                case "Fantastic Metal Sausages": return "segasuaS lateM citsatnaF";
                case "Generic Plastic Soap": return "paoS citsalP cireneG";
                case "protocol": return "locotorp";
                case "relationships": return "spihsnoitaler";
                case "maroon": return "nooram";
                case "capacitor": return "roticapac";
                case "Specialist": return "tsilaicepS";
                case "Officer": return "reciffO";
                case "AGP": return "PGA";
                case "Supervisor": return "rosivrepuS";
                case "Assurance": return "ecnarussA";
                case "Customer": return "remotsuC";
                case "Money Market Account": return "tnuoccA tekraM yenoM";
                case "architectures": return "serutcetihcra";
                case "magenta": return "atnegam";
                case "markets": return "stekram";
                case "array": return "yarra";
                case "Branding": return "gnidnarB";
                case "Central": return "lartneC";
                case "regional": return "lanoiger";
                case "Graphic Interface": return "ecafretnI cihparG";
                case "Road": return "daoR";
                case "hardware": return "erawdrah";
                case "system": return "metsys";
                case "Jordan": return "nadroJ";
                case "intuitive": return "evitiutni";
                case "Consultant": return "tnatlusnoC";
                case "New York": return "kroY weN";
                case "Dobra": return "arboD";
                case "compress": return "sserpmoc";
                case "Norwegian Krone": return "enorK naigewroN";
                case "supply-chains": return "sniahc-ylppus";
                case "Generic Plastic Gloves": return "sevolG citsalP cireneG";
                case "fuchsia": return "aishcuf";
                case "Optimization": return "noitazimitpO";
                case "Data": return "ataD";
                case "Lithuanian Litas": return "satiL nainauhtiL";
                case "enterprise": return "esirpretne";
                case "action-items": return "smeti-noitca";
                case "Sleek Steel Shoes": return "seohS leetS keelS";
                case "Metal": return "lateM";
                case "Uganda Shilling": return "gnillihS adnagU";
                case "International": return "lanoitanretnI";
                case "Tools": return "slooT";
                case "Computers, Beauty \u0026 Health": return "htlaeH \u0026 ytuaeB ,sretupmoC";
                case "Engineer": return "reenignE";
                case "Movies, Home \u0026 Automotive": return "evitomotuA \u0026 emoH ,seivoM";
                case "Dynamic": return "cimanyD";
                case "Incredible Rubber Tuna": return "anuT rebbuR elbidercnI";
                case "digital": return "latigid";
                case "Canada": return "adanaC";
                case "Trail": return "liarT";
                case "Gorgeous": return "suoegroG";
                case "Licensed Metal Tuna": return "anuT lateM desneciL";
                case "Sports \u0026 Baby": return "ybaB \u0026 stropS";
                case "Legacy": return "ycageL";
                case "Industrial \u0026 Automotive": return "evitomotuA \u0026 lairtsudnI";
                case "open-source": return "ecruos-nepo";
                case "next-generation": return "noitareneg-txen";
                case "transform": return "mrofsnart";
                case "JBOD": return "DOBJ";
                case "well-modulated": return "detaludom-llew";
                case "Checking Account": return "tnuoccA gnikcehC";
                case "Kids": return "sdiK";
                case "Investor": return "rotsevnI";
                case "frictionless": return "sselnoitcirf";
                case "overriding": return "gnidirrevo";
                case "customized": return "dezimotsuc";
                case "SCSI": return "ISCS";
                case "Groves": return "sevorG";
                case "Isle": return "elsI";
                case "backing up": return "pu gnikcab";
                case "Platinum": return "munitalP";
                case "card": return "drac";
                case "Toys \u0026 Sports": return "stropS \u0026 syoT";
                case "Small Granite Bike": return "ekiB etinarG llamS";
                case "open architecture": return "erutcetihcra nepo";
                case "Open-source": return "ecruos-nepO";
                case "Handmade Frozen Pizza": return "azziP nezorF edamdnaH";
                case "quantifying": return "gniyfitnauq";
                case "El Salvador Colon": return "noloC rodavlaS lE";
                case "Texas": return "saxeT";
                case "azure": return "eruza";
                case "Executive": return "evitucexE";
                case "Corner": return "renroC";
                case "integrated": return "detargetni";
                case "wireless": return "sseleriw";
                case "challenge": return "egnellahc";
                case "hack": return "kcah";
                case "Utah": return "hatU";
                case "Home, Electronics \u0026 Jewelery": return "yreleweJ \u0026 scinortcelE ,emoH";
                case "Illinois": return "sionillI";
                case "Ergonomic Wooden Tuna": return "anuT nedooW cimonogrE";
                case "Refined Steel Table": return "elbaT leetS denifeR";
                case "approach": return "hcaorppa";
                case "haptic": return "citpah";
                case "European Unit of Account 9(E.U.A.-9)": return ")9-.A.U.E(9 tnuoccA fo tinU naeporuE";
                case "Tasty": return "ytsaT";
                case "Managed": return "deganaM";
                case "Investment Account": return "tnuoccA tnemtsevnI";
                case "Idaho": return "ohadI";
                case "SDD": return "DDS";
                case "Plaza": return "azalP";
                case "deliver": return "reviled";
                case "Unbranded Plastic Gloves": return "sevolG citsalP dednarbnU";
                case "optimize": return "ezimitpo";
                case "Via": return "aiV";
                case "gold": return "dlog";
                case "Path": return "htaP";
                case "Gorgeous Frozen Salad": return "dalaS nezorF suoegroG";
                case "violet": return "teloiv";
                case "Small": return "llamS";
                case "Bermudian Dollar (customarily known as Bermuda Dollar)":
                    return ")ralloD adumreB sa nwonk yliramotsuc( ralloD naidumreB";
                case "Way": return "yaW";
                case "enhance": return "ecnahne";
                case "architect": return "tcetihcra";
                case "Shoes \u0026 Garden": return "nedraG \u0026 seohS";
                case "Meadow": return "wodaeM";
                case "transmitting": return "gnittimsnart";
                case "Cotton": return "nottoC";
                case "Hollow": return "wolloH";
                case "applications": return "snoitacilppa";
                case "Street": return "teertS";
                case "Kentucky": return "ykcutneK";
                case "Hills": return "slliH";
                case "impactful": return "luftcapmi";
                case "New Caledonia": return "ainodelaC weN";
                case "Ridge": return "egdiR";
                case "purple": return "elprup";
                case "Marketing": return "gnitekraM";
                case "Norway": return "yawroN";
                case "Tasty Wooden Sausages": return "segasuaS nedooW ytsaT";
                case "Agent": return "tnegA";
                case "Accountability": return "ytilibatnuoccA";
                case "Sleek Rubber Towels": return "slewoT rebbuR keelS";
                case "Cordoba Oro": return "orO abodroC";
                case "encoding": return "gnidocne";
                case "Division": return "noisiviD";
                case "District": return "tcirtsiD";
                case "user-centric": return "cirtnec-resu";
                case "Practical Concrete Ball": return "llaB etercnoC lacitcarP";
                case "multi-byte": return "etyb-itlum";
                case "IB": return "BI";
                case "Uganda": return "adnagU";
                case "unleash": return "hsaelnu";
                case "Handcrafted Soft Keyboard": return "draobyeK tfoS detfarcdnaH";
                case "Shore": return "erohS";
                case "Director": return "rotceriD";
                case "architecture": return "erutcetihcra";
                case "Mozambique": return "euqibmazoM";
                case "explicit": return "ticilpxe";
                case "infrastructures": return "serutcurtsarfni";
                case "Bond Markets Units European Composite Unit (EURCO)":
                    return ")OCRUE( tinU etisopmoC naeporuE stinU stekraM dnoB";
                case "Keys": return "syeK";
                case "e-markets": return "stekram-e";
                case "Business-focused": return "desucof-ssenisuB";
                case "Small Frozen Hat": return "taH nezorF llamS";
                case "Rustic Wooden Sausages": return "segasuaS nedooW citsuR";
                case "plug-and-play": return "yalp-dna-gulp";
                case "visualize": return "ezilausiv";
                case "Licensed Concrete Computer": return "retupmoC etercnoC desneciL";
                case "Burgs": return "sgruB";
                case "Versatile": return "elitasreV";
                case "Practical Rubber Chicken": return "nekcihC rebbuR lacitcarP";
                case "Generic Granite Ball": return "llaB etinarG cireneG";
                case "bleeding-edge": return "egde-gnideelb";
                case "Locks": return "skcoL";
                case "orchid": return "dihcro";
                case "Handmade Steel Keyboard": return "draobyeK leetS edamdnaH";
                case "Product": return "tcudorP";
                case "Nevada": return "adaveN";
                case "Synergized": return "dezigrenyS";
                case "indexing": return "gnixedni";
                case "plum": return "mulp";
                case "Baby": return "ybaB";
                case "Skyway": return "yawykS";
                case "Junction": return "noitcnuJ";
                case "Ergonomic Fresh Gloves": return "sevolG hserF cimonogrE";
                case "portals": return "slatrop";
                case "capability": return "ytilibapac";
                case "Intelligent Cotton Soap": return "paoS nottoC tnegilletnI";
                case "strategize": return "ezigetarts";
                case "Electronics": return "scinortcelE";
                case "Awesome Fresh Chicken": return "nekcihC hserF emosewA";
                case "Passage": return "egassaP";
                case "orange": return "egnaro";
                case "Malawi": return "iwalaM";
                case "exuding": return "gniduxe";
                case "Technician": return "naicinhceT";
                case "View": return "weiV";
                case "Intelligent Plastic Salad": return "dalaS citsalP tnegilletnI";
                case "Montana": return "anatnoM";
                case "uniform": return "mrofinu";
                case "Lebanese Pound": return "dnuoP esenabeL";
                case "Indiana": return "anaidnI";
                case "optical": return "lacitpo";
                case "Incredible Concrete Bike": return "ekiB etercnoC elbidercnI";
                case "Saudi Riyal": return "layiR iduaS";
                case "generate": return "etareneg";
                case "Moldova": return "avodloM";
                case "driver": return "revird";
                case "Swiss Franc": return "cnarF ssiwS";
                case "Mobility": return "ytiliboM";
                case "Guinea": return "aeniuG";
                case "ability": return "ytiliba";
                case "Curve": return "evruC";
                case "Flat": return "talF";
                case "transmitter": return "rettimsnart";
                case "Outdoors, Clothing \u0026 Games": return "semaG \u0026 gnihtolC ,sroodtuO";
                case "Health, Movies \u0026 Books": return "skooB \u0026 seivoM ,htlaeH";
                case "Mountains": return "sniatnuoM";
                case "Identity": return "ytitnedI";
                case "budgetary management": return "tnemeganam yrategdub";
                case "Isle of Man": return "naM fo elsI";
                case "full-range": return "egnar-lluf";
                case "directional": return "lanoitcerid";
                case "SQL": return "LQS";
                case "Configurable": return "elbarugifnoC";
                case "Awesome Rubber Chicken": return "nekcihC rebbuR emosewA";
                case "Group": return "puorG";
                case "Island": return "dnalsI";
                case "Handmade Fresh Hat": return "taH hserF edamdnaH";
                case "Guarani": return "inarauG";
                case "harness": return "ssenrah";
                case "Usability": return "ytilibasU";
                case "override": return "edirrevo";
                case "heuristic": return "citsirueh";
                case "Uruguay": return "yaugurU";
                case "Handmade": return "edamdnaH";
                case "global": return "labolg";
                case "Fantastic Soft Shirt": return "trihS tfoS citsatnaF";
                case "solid state": return "etats dilos";
                case "Roads": return "sdaoR";
                case "bypassing": return "gnissapyb";
                case "Station": return "noitatS";
                case "Licensed Fresh Pizza": return "azziP hserF desneciL";
                case "blockchains": return "sniahckcolb";
                case "Land": return "dnaL";
                case "Bouvet Island (Bouvetoya)": return ")ayotevuoB( dnalsI tevuoB";
                case "Handcrafted Frozen Hat": return "taH nezorF detfarcdnaH";
                case "Future-proofed": return "defoorp-erutuF";
                case "Grenada": return "adanerG";
                case "Tools, Kids \u0026 Home": return "emoH \u0026 sdiK ,slooT";
                case "Ports": return "stroP";
                case "proactive": return "evitcaorp";
                case "Pennsylvania": return "ainavlysnneP";
                case "Convertible Marks": return "skraM elbitrevnoC";
                case "Awesome Plastic Pants": return "stnaP citsalP emosewA";
                case "projection": return "noitcejorp";
                case "Games, Clothing \u0026 Industrial": return "lairtsudnI \u0026 gnihtolC ,semaG";
                case "Djibouti Franc": return "cnarF ituobijD";
                case "Generic Steel Pizza": return "azziP leetS cireneG";
                case "Web": return "beW";
                case "Adaptive": return "evitpadA";
                case "Electronics, Toys \u0026 Garden": return "nedraG \u0026 syoT ,scinortcelE";
                case "Refined Granite Sausages": return "segasuaS etinarG denifeR";
                case "South Africa": return "acirfA htuoS";
                case "parse": return "esrap";
                case "Handmade Concrete Bike": return "ekiB etercnoC edamdnaH";
                case "Practical Plastic Cheese": return "eseehC citsalP lacitcarP";
                case "Somoni": return "inomoS";
                case "Valleys": return "syellaV";
                case "Bahamian Dollar": return "ralloD naimahaB";
                case "Awesome Wooden Bike": return "ekiB nedooW emosewA";
                case "Generic Frozen Hat": return "taH nezorF cireneG";
                case "Re-contextualized": return "dezilautxetnoc-eR";
                case "Martinique": return "euqinitraM";
                case "bypass": return "ssapyb";
                case "Tasty Fresh Chips": return "spihC hserF ytsaT";
                case "Mexican Peso": return "oseP nacixeM";
                case "Kyat": return "tayK";
                case "Alabama": return "amabalA";
                case "Crossing": return "gnissorC";
                case "Generic Rubber Keyboard": return "draobyeK rebbuR cireneG";
                case "Intelligent Soft Sausages": return "segasuaS tfoS tnegilletnI";
                case "Jewelery, Games \u0026 Music": return "cisuM \u0026 semaG ,yreleweJ";
                case "Puerto Rico": return "ociR otreuP";
                case "Open-architected": return "detcetihcra-nepO";
                case "Croatian Kuna": return "anuK naitaorC";
                case "Beauty \u0026 Computers": return "sretupmoC \u0026 ytuaeB";
                case "Incredible": return "elbidercnI";
                case "Virginia": return "ainigriV";
                case "Saint Helena": return "aneleH tniaS";
                case "Virgin Islands, U.S.": return ".S.U ,sdnalsI nigriV";
                case "Persevering": return "gnirevesreP";
                case "Rustic Frozen Computer": return "retupmoC nezorF citsuR";
                case "Refined Concrete Tuna": return "anuT etercnoC denifeR";
                case "homogeneous": return "suoenegomoh";
                case "real-time": return "emit-laer";
                case "New Jersey": return "yesreJ weN";
                case "dot-com": return "moc-tod";
                case "Ohio": return "oihO";
                case "FTP": return "PTF";
                case "Unbranded Granite Towels": return "slewoT etinarG dednarbnU";
                case "innovate": return "etavonni";
                case "Awesome Cotton Chicken": return "nekcihC nottoC emosewA";
                case "United States Minor Outlying Islands": return "sdnalsI gniyltuO roniM setatS detinU";
                case "Plain": return "nialP";
                case "Terrace": return "ecarreT";
                case "redundant": return "tnadnuder";
                case "Function-based": return "desab-noitcnuF";
                case "Toys": return "syoT";
                case "rich": return "hcir";
                case "sensor": return "rosnes";
                case "connecting": return "gnitcennoc";
                case "networks": return "skrowten";
                case "Configuration": return "noitarugifnoC";
                case "Proactive": return "evitcaorP";
                case "solutions": return "snoitulos";
                case "Handmade Steel Fish": return "hsiF leetS edamdnaH";
                case "Tasty Steel Chicken": return "nekcihC leetS ytsaT";
                case "Highway": return "yawhgiH";
                case "integrate": return "etargetni";
                case "RAM": return "MAR";
                case "Practical Concrete Shoes": return "seohS etercnoC lacitcarP";
                case "Health, Music \u0026 Beauty": return "ytuaeB \u0026 cisuM ,htlaeH";
                case "users": return "sresu";
                case "Flats": return "stalF";
                case "robust": return "tsubor";
                case "Pass": return "ssaP";
                case "mobile": return "elibom";
                case "non-volatile": return "elitalov-non";
                case "auxiliary": return "yrailixua";
                default:
                    return value;
            }
        }
    }
}