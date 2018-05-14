namespace Agate.Business.Services
{
    public class CountryDetails
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string DialingCode { get; set; }
        public string Display => $"{CountryName} ({DialingCode})";
    }

    public class CountriesData
    {
        static CountriesData()
        {
            List = new[]
            {
                new CountryDetails
                {
                    CountryCode="AF",
                    CountryName = "Afghanistan",
                    DialingCode = "+93"
                },
                new CountryDetails
                {
                    CountryCode="AL",
                    CountryName = "Albania",
                    DialingCode = "+355"
                },
                new CountryDetails
                {
                    CountryCode="DZ",
                    CountryName = "Algeria",
                    DialingCode = "+213"
                },
                new CountryDetails
                {
                    CountryCode="AS",
                    CountryName = "American Samoa",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="AD",
                    CountryName = "Andorra",
                    DialingCode = "+376"
                },
                new CountryDetails
                {
                    CountryCode="AO",
                    CountryName = "Angola",
                    DialingCode = "+244"
                },
                new CountryDetails
                {
                    CountryCode="AI",
                    CountryName = "Anguilla",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="AG",
                    CountryName = "Antigua",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="AR",
                    CountryName = "Argentina",
                    DialingCode = "+54"
                },
                new CountryDetails
                {
                    CountryCode="AM",
                    CountryName = "Armenia",
                    DialingCode = "+374"
                },
                new CountryDetails
                {
                    CountryCode="AW",
                    CountryName = "Aruba",
                    DialingCode = "+297"
                },
                new CountryDetails
                {
                    CountryCode="AU",
                    CountryName = "Australia",
                    DialingCode = "+61"
                },
                new CountryDetails
                {
                    CountryCode="AI",
                    CountryName = "Austria",
                    DialingCode = "+43"
                },
                new CountryDetails
                {
                    CountryCode="AZ",
                    CountryName = "Azerbaijan",
                    DialingCode = "+994"
                },
                new CountryDetails
                {
                    CountryCode="BH",
                    CountryName = "Bahrain",
                    DialingCode = "+973"
                },
                new CountryDetails
                {
                    CountryCode="BD",
                    CountryName = "Bangladesh",
                    DialingCode = "+880"
                },
                new CountryDetails
                {
                    CountryCode="BB",
                    CountryName = "Barbados",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="BY",
                    CountryName = "Belarus",
                    DialingCode = "+375"
                },
                new CountryDetails
                {
                    CountryCode="BE",
                    CountryName = "Belgium",
                    DialingCode = "+32"
                },
                new CountryDetails
                {
                    CountryCode="BZ",
                    CountryName = "Belize",
                    DialingCode = "+501"
                },
                new CountryDetails
                {
                    CountryCode="BJ",
                    CountryName = "Benin",
                    DialingCode = "+229"
                },
                new CountryDetails
                {
                    CountryCode="BM",
                    CountryName = "Bermuda",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="BT",
                    CountryName = "Bhutan",
                    DialingCode = "+975"
                },
                new CountryDetails
                {
                    CountryCode="BO",
                    CountryName = "Bolivia",
                    DialingCode = "+591"
                },
                new CountryDetails
                {
                    CountryCode="BA",
                    CountryName = "Bosnia and Herzegovina",
                    DialingCode = "+387"
                },
                new CountryDetails
                {
                    CountryCode="BW",
                    CountryName = "Botswana",
                    DialingCode = "+267"
                },
                new CountryDetails
                {
                    CountryCode="BR",
                    CountryName = "Brazil",
                    DialingCode = "+55"
                },
                new CountryDetails
                {
                    CountryCode="IO",
                    CountryName = "British Indian Ocean Territory",
                    DialingCode = "+246"
                },
                new CountryDetails
                {
                    CountryCode="VG",
                    CountryName = "British Virgin Islands",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="BN",
                    CountryName = "Brunei",
                    DialingCode = "+673"
                },
                new CountryDetails
                {
                    CountryCode="BG",
                    CountryName = "Bulgaria",
                    DialingCode = "+359"
                },
                new CountryDetails
                {
                    CountryCode="BF",
                    CountryName = "Burkina Faso",
                    DialingCode = "+226"
                },
                new CountryDetails
                {
                    CountryCode="MM",
                    CountryName = "Burma Myanmar",
                    DialingCode = "+95"
                },
                new CountryDetails
                {
                    CountryCode="BI",
                    CountryName = "Burundi",
                    DialingCode = "+257"
                },
                new CountryDetails
                {
                    CountryCode="KH",
                    CountryName = "Cambodia",
                    DialingCode = "+855"
                },
                new CountryDetails
                {
                    CountryCode="CM",
                    CountryName = "Cameroon",
                    DialingCode = "+237"
                },
                new CountryDetails
                {
                    CountryCode="CA",
                    CountryName = "Canada",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="CV",
                    CountryName = "Cape Verde",
                    DialingCode = "+238"
                },
                new CountryDetails
                {
                    CountryCode="KY",
                    CountryName = "Cayman Islands",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="CF",
                    CountryName = "Central African Republic",
                    DialingCode = "+236"
                },
                new CountryDetails
                {
                    CountryCode="ID",
                    CountryName = "Chad",
                    DialingCode = "+235"
                },
                new CountryDetails
                {
                    CountryCode="CL",
                    CountryName = "Chile",
                    DialingCode = "+56"
                },
                new CountryDetails
                {
                    CountryCode="CN",
                    CountryName = "China",
                    DialingCode = "+86"
                },
                new CountryDetails
                {
                    CountryCode="CO",
                    CountryName = "Colombia",
                    DialingCode = "+57"
                },
                new CountryDetails
                {
                    CountryCode="KM",
                    CountryName = "Comoros",
                    DialingCode = "+269"
                },
                new CountryDetails
                {
                    CountryCode="CK",
                    CountryName = "Cook Islands",
                    DialingCode = "+682"
                },
                new CountryDetails
                {
                    CountryCode="CR",
                    CountryName = "Costa Rica",
                    DialingCode = "+506"
                },
                new CountryDetails
                {
                    CountryCode="CI",
                    CountryName = "Côte d'Ivoire",
                    DialingCode = "+225"
                },
                new CountryDetails
                {
                    CountryCode="HR",
                    CountryName = "Croatia",
                    DialingCode = "+385"
                },
                new CountryDetails
                {
                    CountryCode="CU",
                    CountryName = "Cuba",
                    DialingCode = "+53"
                },
                new CountryDetails
                {
                    CountryCode="CY",
                    CountryName = "Cyprus",
                    DialingCode = "+357"
                },
                new CountryDetails
                {
                    CountryCode="CZ",
                    CountryName = "Czech Republic",
                    DialingCode = "+420"
                },
                new CountryDetails
                {
                    CountryCode="CD",
                    CountryName = "Democratic Republic of Congo",
                    DialingCode = "+243"
                },
                new CountryDetails
                {
                    CountryCode="DK",
                    CountryName = "Denmark",
                    DialingCode = "+45"
                },
                new CountryDetails
                {
                    CountryCode="DJ",
                    CountryName = "Djibouti",
                    DialingCode = "+253"
                },
                new CountryDetails
                {
                    CountryCode="DM",
                    CountryName = "Dominica",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="DO",
                    CountryName = "Dominican Republic",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="EC",
                    CountryName = "Ecuador",
                    DialingCode = "+593"
                },
                new CountryDetails
                {
                    CountryCode="EG",
                    CountryName = "Egypt",
                    DialingCode = "+20"
                },
                new CountryDetails
                {
                    CountryCode="SV",
                    CountryName = "El Salvador",
                    DialingCode = "+503"
                },
                new CountryDetails
                {
                    CountryCode="GQ",
                    CountryName = "Equatorial Guinea",
                    DialingCode = "+240"
                },
                new CountryDetails
                {
                    CountryCode="ER",
                    CountryName = "Eritrea",
                    DialingCode = "+291"
                },
                new CountryDetails
                {
                    CountryCode="EE",
                    CountryName = "Estonia",
                    DialingCode = "+372"
                },
                new CountryDetails
                {
                    CountryCode="ET",
                    CountryName = "Ethiopia",
                    DialingCode = "+251"
                },
                new CountryDetails
                {
                    CountryCode="FK",
                    CountryName = "Falkland Islands",
                    DialingCode = "+500"
                },
                new CountryDetails
                {
                    CountryCode="FO",
                    CountryName = "Faroe Islands",
                    DialingCode = "+298"
                },
                new CountryDetails
                {
                    CountryCode="FM",
                    CountryName = "Federated States of Micronesia",
                    DialingCode = "+691"
                },
                new CountryDetails
                {
                    CountryCode="FJ",
                    CountryName = "Fiji",
                    DialingCode = "+679"
                },
                new CountryDetails
                {
                    CountryCode="FI",
                    CountryName = "Finland",
                    DialingCode = "+358"
                },
                new CountryDetails
                {
                    CountryCode="FR",
                    CountryName = "France",
                    DialingCode = "+33"
                },
                new CountryDetails
                {
                    CountryCode="GF",
                    CountryName = "French Guiana",
                    DialingCode = "+594"
                },
                new CountryDetails
                {
                    CountryCode="PF",
                    CountryName = "French Polynesia",
                    DialingCode = "+689"
                },
                new CountryDetails
                {
                    CountryCode="GA",
                    CountryName = "Gabon",
                    DialingCode = "+241"
                },
                new CountryDetails
                {
                    CountryCode="GE",
                    CountryName = "Georgia",
                    DialingCode = "+995"
                },
                new CountryDetails
                {
                    CountryCode="DE",
                    CountryName = "Germany",
                    DialingCode = "+49"
                },
                new CountryDetails
                {
                    CountryCode="GH",
                    CountryName = "Ghana",
                    DialingCode = "+233"
                },
                new CountryDetails
                {
                    CountryCode="GI",
                    CountryName = "Gibraltar",
                    DialingCode = "+350"
                },
                new CountryDetails
                {
                    CountryCode="GR",
                    CountryName = "Greece",
                    DialingCode = "+30"
                },
                new CountryDetails
                {
                    CountryCode="GL",
                    CountryName = "Greenland",
                    DialingCode = "+299"
                },
                new CountryDetails
                {
                    CountryCode="GD",
                    CountryName = "Grenada",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="GP",
                    CountryName = "Guadeloupe",
                    DialingCode = "+590"
                },
                new CountryDetails
                {
                    CountryCode="GU",
                    CountryName = "Guam",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="GT",
                    CountryName = "Guatemala",
                    DialingCode = "+502"
                },
                new CountryDetails
                {
                    CountryCode="GN",
                    CountryName = "Guinea",
                    DialingCode = "+224"
                },
                new CountryDetails
                {
                    CountryCode="GW",
                    CountryName = "Guinea-Bissau",
                    DialingCode = "+245"
                },
                new CountryDetails
                {
                    CountryCode="GY",
                    CountryName = "Guyana",
                    DialingCode = "+592"
                },
                new CountryDetails
                {
                    CountryCode="HT",
                    CountryName = "Haiti",
                    DialingCode = "+509"
                },
                new CountryDetails
                {
                    CountryCode="HN",
                    CountryName = "Honduras",
                    DialingCode = "+504"
                },
                new CountryDetails
                {
                    CountryCode="HK",
                    CountryName = "Hong Kong",
                    DialingCode = "+852"
                },
                new CountryDetails
                {
                    CountryCode="HU",
                    CountryName = "Hungary",
                    DialingCode = "+36"
                },
                new CountryDetails
                {
                    CountryCode="IS",
                    CountryName = "Iceland",
                    DialingCode = "+354"
                },
                new CountryDetails
                {
                    CountryCode="IN",
                    CountryName = "India",
                    DialingCode = "+91"
                },
                new CountryDetails
                {
                    CountryCode="ID",
                    CountryName = "Indonesia",
                    DialingCode = "+62"
                },
                new CountryDetails
                {
                    CountryCode="IR",
                    CountryName = "Iran",
                    DialingCode = "+98"
                },
                new CountryDetails
                {
                    CountryCode="IQ",
                    CountryName = "Iraq",
                    DialingCode = "+964"
                },
                new CountryDetails
                {
                    CountryCode="IE",
                    CountryName = "Ireland",
                    DialingCode = "+353"
                },
                new CountryDetails
                {
                    CountryCode="IL",
                    CountryName = "Israel",
                    DialingCode = "+972"
                },
                new CountryDetails
                {
                    CountryCode="IT",
                    CountryName = "Italy",
                    DialingCode = "+39"
                },
                new CountryDetails
                {
                    CountryCode="JM",
                    CountryName = "Jamaica",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="JP",
                    CountryName = "Japan",
                    DialingCode = "+81"
                },
                new CountryDetails
                {
                    CountryCode="JO",
                    CountryName = "Jordan",
                    DialingCode = "+962"
                },
                new CountryDetails
                {
                    CountryCode="KZ",
                    CountryName = "Kazakhstan",
                    DialingCode = "+7"
                },
                new CountryDetails
                {
                    CountryCode="KE",
                    CountryName = "Kenya",
                    DialingCode = "+254"
                },
                new CountryDetails
                {
                    CountryCode="KI",
                    CountryName = "Kiribati",
                    DialingCode = "+686"
                },
                new CountryDetails
                {
                    CountryCode="XK",
                    CountryName = "Kosovo",
                    DialingCode = "+381"
                },
                new CountryDetails
                {
                    CountryCode="KW",
                    CountryName = "Kuwait",
                    DialingCode = "+965"
                },
                new CountryDetails
                {
                    CountryCode="KG",
                    CountryName = "Kyrgyzstan",
                    DialingCode = "+996"
                },
                new CountryDetails
                {
                    CountryCode="LA",
                    CountryName = "Laos",
                    DialingCode = "+856"
                },
                new CountryDetails
                {
                    CountryCode="LV",
                    CountryName = "Latvia",
                    DialingCode = "+371"
                },
                new CountryDetails
                {
                    CountryCode="LB",
                    CountryName = "Lebanon",
                    DialingCode = "+961"
                },
                new CountryDetails
                {
                    CountryCode="LS",
                    CountryName = "Lesotho",
                    DialingCode = "+266"
                },
                new CountryDetails
                {
                    CountryCode="LR",
                    CountryName = "Liberia",
                    DialingCode = "+231"
                },
                new CountryDetails
                {
                    CountryCode="LY",
                    CountryName = "Libya",
                    DialingCode = "+218"
                },
                new CountryDetails
                {
                    CountryCode="LI",
                    CountryName = "Liechtenstein",
                    DialingCode = "+423"
                },
                new CountryDetails
                {
                    CountryCode="LT",
                    CountryName = "Lithuania",
                    DialingCode = "+370"
                },
                new CountryDetails
                {
                    CountryCode="LU",
                    CountryName = "Luxembourg",
                    DialingCode = "+352"
                },
                new CountryDetails
                {
                    CountryCode="MO",
                    CountryName = "Macau",
                    DialingCode = "+853"
                },
                new CountryDetails
                {
                    CountryCode="MK",
                    CountryName = "Macedonia",
                    DialingCode = "+389"
                },
                new CountryDetails
                {
                    CountryCode="MG",
                    CountryName = "Madagascar",
                    DialingCode = "+261"
                },
                new CountryDetails
                {
                    CountryCode="MW",
                    CountryName = "Malawi",
                    DialingCode = "+265"
                },
                new CountryDetails
                {
                    CountryCode="MY",
                    CountryName = "Malaysia",
                    DialingCode = "+60"
                },
                new CountryDetails
                {
                    CountryCode="MV",
                    CountryName = "Maldives",
                    DialingCode = "+960"
                },
                new CountryDetails
                {
                    CountryCode="ML",
                    CountryName = "Mali",
                    DialingCode = "+223"
                },
                new CountryDetails
                {
                    CountryCode="MT",
                    CountryName = "Malta",
                    DialingCode = "+356"
                },
                new CountryDetails
                {
                    CountryCode="MH",
                    CountryName = "Marshall Islands",
                    DialingCode = "+692"
                },
                new CountryDetails
                {
                    CountryCode="MQ",
                    CountryName = "Martinique",
                    DialingCode = "+596"
                },
                new CountryDetails
                {
                    CountryCode="MR",
                    CountryName = "Mauritania",
                    DialingCode = "+222"
                },
                new CountryDetails
                {
                    CountryCode="MU",
                    CountryName = "Mauritius",
                    DialingCode = "+230"
                },
                new CountryDetails
                {
                    CountryCode="YT",
                    CountryName = "Mayotte",
                    DialingCode = "+262"
                },
                new CountryDetails
                {
                    CountryCode="MX",
                    CountryName = "Mexico",
                    DialingCode = "+52"
                },
                new CountryDetails
                {
                    CountryCode="MD",
                    CountryName = "Moldova",
                    DialingCode = "+373"
                },
                new CountryDetails
                {
                    CountryCode="MC",
                    CountryName = "Monaco",
                    DialingCode = "+377"
                },
                new CountryDetails
                {
                    CountryCode="MN",
                    CountryName = "Mongolia",
                    DialingCode = "+976"
                },
                new CountryDetails
                {
                    CountryCode="ME",
                    CountryName = "Montenegro",
                    DialingCode = "+382"
                },
                new CountryDetails
                {
                    CountryCode="MS",
                    CountryName = "Montserrat",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="MA",
                    CountryName = "Morocco",
                    DialingCode = "+212"
                },
                new CountryDetails
                {
                    CountryCode="MZ",
                    CountryName = "Mozambique",
                    DialingCode = "+258"
                },
                new CountryDetails
                {
                    CountryCode="NA",
                    CountryName = "Namibia",
                    DialingCode = "+264"
                },
                new CountryDetails
                {
                    CountryCode="NR",
                    CountryName = "Nauru",
                    DialingCode = "+674"
                },
                new CountryDetails
                {
                    CountryCode="NP",
                    CountryName = "Nepal",
                    DialingCode = "+977"
                },
                new CountryDetails
                {
                    CountryCode="NL",
                    CountryName = "Netherlands",
                    DialingCode = "+31"
                },
                new CountryDetails
                {
                    CountryCode="AN",
                    CountryName = "Netherlands Antilles",
                    DialingCode = "+599"
                },
                new CountryDetails
                {
                    CountryCode="NC",
                    CountryName = "New Caledonia",
                    DialingCode = "+687"
                },
                new CountryDetails
                {
                    CountryCode="NZ",
                    CountryName = "New Zealand",
                    DialingCode = "+64"
                },
                new CountryDetails
                {
                    CountryCode="NI",
                    CountryName = "Nicaragua",
                    DialingCode = "+505"
                },
                new CountryDetails
                {
                    CountryCode="NE",
                    CountryName = "Niger",
                    DialingCode = "+227"
                },
                new CountryDetails
                {
                    CountryCode="NG",
                    CountryName = "Nigeria",
                    DialingCode = "+234"
                },
                new CountryDetails
                {
                    CountryCode="NU",
                    CountryName = "Niue",
                    DialingCode = "+683"
                },
                new CountryDetails
                {
                    CountryCode="NF",
                    CountryName = "Norfolk Island",
                    DialingCode = "+672"
                },
                new CountryDetails
                {
                    CountryCode="KP",
                    CountryName = "North Korea",
                    DialingCode = "+850"
                },
                new CountryDetails
                {
                    CountryCode="MP",
                    CountryName = "Northern Mariana Islands",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="NO",
                    CountryName = "Norway",
                    DialingCode = "+47"
                },
                new CountryDetails
                {
                    CountryCode="OM",
                    CountryName = "Oman",
                    DialingCode = "+968"
                },
                new CountryDetails
                {
                    CountryCode="PK",
                    CountryName = "Pakistan",
                    DialingCode = "+92"
                },
                new CountryDetails
                {
                    CountryCode="PW",
                    CountryName = "Palau",
                    DialingCode = "+680"
                },
                new CountryDetails
                {
                    CountryCode="PS",
                    CountryName = "Palestine",
                    DialingCode = "+970"
                },
                new CountryDetails
                {
                    CountryCode="PA",
                    CountryName = "Panama",
                    DialingCode = "+507"
                },
                new CountryDetails
                {
                    CountryCode="PG",
                    CountryName = "Papua New Guinea",
                    DialingCode = "+675"
                },
                new CountryDetails
                {
                    CountryCode="PY",
                    CountryName = "Paraguay",
                    DialingCode = "+595"
                },
                new CountryDetails
                {
                    CountryCode="PE",
                    CountryName = "Peru",
                    DialingCode = "+51"
                },
                new CountryDetails
                {
                    CountryCode="PH",
                    CountryName = "Philippines",
                    DialingCode = "+63"
                },
                new CountryDetails
                {
                    CountryCode="PL",
                    CountryName = "Poland",
                    DialingCode = "+48"
                },
                new CountryDetails
                {
                    CountryCode="PT",
                    CountryName = "Portugal",
                    DialingCode = "+351"
                },
                new CountryDetails
                {
                    CountryCode="PR",
                    CountryName = "Puerto Rico",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="QA",
                    CountryName = "Qatar",
                    DialingCode = "+974"
                },
                new CountryDetails
                {
                    CountryCode="CG",
                    CountryName = "Republic of the Congo",
                    DialingCode = "+242"
                },
                new CountryDetails
                {
                    CountryCode="RE",
                    CountryName = "Réunion",
                    DialingCode = "+262"
                },
                new CountryDetails
                {
                    CountryCode="RO",
                    CountryName = "Romania",
                    DialingCode = "+40"
                },
                new CountryDetails
                {
                    CountryCode="RU",
                    CountryName = "Russia",
                    DialingCode = "+7"
                },
                new CountryDetails
                {
                    CountryCode="RW",
                    CountryName = "Rwanda",
                    DialingCode = "+250"
                },
                new CountryDetails
                {
                    CountryCode="BL",
                    CountryName = "Saint Barthélemy",
                    DialingCode = "+590"
                },
                new CountryDetails
                {
                    CountryCode="SH",
                    CountryName = "Saint Helena",
                    DialingCode = "+290"
                },
                new CountryDetails
                {
                    CountryCode="KN",
                    CountryName = "Saint Kitts and Nevis",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="MF",
                    CountryName = "Saint Martin",
                    DialingCode = "+590"
                },
                new CountryDetails
                {
                    CountryCode="PM",
                    CountryName = "Saint Pierre and Miquelon",
                    DialingCode = "+508"
                },
                new CountryDetails
                {
                    CountryCode="VC",
                    CountryName = "Saint Vincent and the Grenadines",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="WS",
                    CountryName = "Samoa",
                    DialingCode = "+685"
                },
                new CountryDetails
                {
                    CountryCode="SM",
                    CountryName = "San Marino",
                    DialingCode = "+378"
                },
                new CountryDetails
                {
                    CountryCode="ST",
                    CountryName = "São Tomé and Príncipe",
                    DialingCode = "+239"
                },
                new CountryDetails
                {
                    CountryCode="SA",
                    CountryName = "Saudi Arabia",
                    DialingCode = "+966"
                },
                new CountryDetails
                {
                    CountryCode="SN",
                    CountryName = "Senegal",
                    DialingCode = "+221"
                },
                new CountryDetails
                {
                    CountryCode="RS",
                    CountryName = "Serbia",
                    DialingCode = "+381"
                },
                new CountryDetails
                {
                    CountryCode="SC",
                    CountryName = "Seychelles",
                    DialingCode = "+248"
                },
                new CountryDetails
                {
                    CountryCode="SL",
                    CountryName = "Sierra Leone",
                    DialingCode = "+232"
                },
                new CountryDetails
                {
                    CountryCode="SG",
                    CountryName = "Singapore",
                    DialingCode = "+65"
                },
                new CountryDetails
                {
                    CountryCode="SK",
                    CountryName = "Slovakia",
                    DialingCode = "+421"
                },
                new CountryDetails
                {
                    CountryCode="SI",
                    CountryName = "Slovenia",
                    DialingCode = "+386"
                },
                new CountryDetails
                {
                    CountryCode="SB",
                    CountryName = "Solomon Islands",
                    DialingCode = "+677"
                },
                new CountryDetails
                {
                    CountryCode="SO",
                    CountryName = "Somalia",
                    DialingCode = "+252"
                },
                new CountryDetails
                {
                    CountryCode="ZA",
                    CountryName = "South Africa",
                    DialingCode = "+27"
                },
                new CountryDetails
                {
                    CountryCode="KR",
                    CountryName = "South Korea",
                    DialingCode = "+82"
                },
                new CountryDetails
                {
                    CountryCode="ES",
                    CountryName = "Spain",
                    DialingCode = "+34"
                },
                new CountryDetails
                {
                    CountryCode="LK",
                    CountryName = "Sri Lanka",
                    DialingCode = "+94"
                },
                new CountryDetails
                {
                    CountryCode="LC",
                    CountryName = "St. Lucia",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="SD",
                    CountryName = "Sudan",
                    DialingCode = "+249"
                },
                new CountryDetails
                {
                    CountryCode="SR",
                    CountryName = "Suriname",
                    DialingCode = "+597"
                },
                new CountryDetails
                {
                    CountryCode="SZ",
                    CountryName = "Swaziland",
                    DialingCode = "+268"
                },
                new CountryDetails
                {
                    CountryCode="SE",
                    CountryName = "Sweden",
                    DialingCode = "+46"
                },
                new CountryDetails
                {
                    CountryCode="CH",
                    CountryName = "Switzerland",
                    DialingCode = "+41"
                },
                new CountryDetails
                {
                    CountryCode="SY",
                    CountryName = "Syria",
                    DialingCode = "+963"
                },
                new CountryDetails
                {
                    CountryCode="TW",
                    CountryName = "Taiwan",
                    DialingCode = "+886"
                },
                new CountryDetails
                {
                    CountryCode="TJ",
                    CountryName = "Tajikistan",
                    DialingCode = "+992"
                },
                new CountryDetails
                {
                    CountryCode="TZ",
                    CountryName = "Tanzania",
                    DialingCode = "+255"
                },
                new CountryDetails
                {
                    CountryCode="TH",
                    CountryName = "Thailand",
                    DialingCode = "+66"
                },
                new CountryDetails
                {
                    CountryCode="BS",
                    CountryName = "The Bahamas",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="GM",
                    CountryName = "The Gambia",
                    DialingCode = "+220"
                },
                new CountryDetails
                {
                    CountryCode="TL",
                    CountryName = "Timor-Leste",
                    DialingCode = "+670"
                },
                new CountryDetails
                {
                    CountryCode="TG",
                    CountryName = "Togo",
                    DialingCode = "+228"
                },
                new CountryDetails
                {
                    CountryCode="TK",
                    CountryName = "Tokelau",
                    DialingCode = "+690"
                },
                new CountryDetails
                {
                    CountryCode="TO",
                    CountryName = "Tonga",
                    DialingCode = "+676"
                },
                new CountryDetails
                {
                    CountryCode="TT",
                    CountryName = "Trinidad and Tobago",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="TN",
                    CountryName = "Tunisia",
                    DialingCode = "+216"
                },
                new CountryDetails
                {
                    CountryCode="TR",
                    CountryName = "Turkey",
                    DialingCode = "+90"
                },
                new CountryDetails
                {
                    CountryCode="TM",
                    CountryName = "Turkmenistan",
                    DialingCode = "+993"
                },
                new CountryDetails
                {
                    CountryCode="TC",
                    CountryName = "Turks and Caicos Islands",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="TV",
                    CountryName = "Tuvalu",
                    DialingCode = "+688"
                },
                new CountryDetails
                {
                    CountryCode="UG",
                    CountryName = "Uganda",
                    DialingCode = "+256"
                },
                new CountryDetails
                {
                    CountryCode="UA",
                    CountryName = "Ukraine",
                    DialingCode = "+380"
                },
                new CountryDetails
                {
                    CountryCode="AE",
                    CountryName = "United Arab Emirates",
                    DialingCode = "+971"
                },
                new CountryDetails
                {
                    CountryCode="GB",
                    CountryName = "United Kingdom",
                    DialingCode = "+44"
                },
                new CountryDetails
                {
                    CountryCode="US",
                    CountryName = "United States",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="UY",
                    CountryName = "Uruguay",
                    DialingCode = "+598"
                },
                new CountryDetails
                {
                    CountryCode="VI",
                    CountryName = "US Virgin Islands",
                    DialingCode = "+1"
                },
                new CountryDetails
                {
                    CountryCode="UZ",
                    CountryName = "Uzbekistan",
                    DialingCode = "+998"
                },
                new CountryDetails
                {
                    CountryCode="VU",
                    CountryName = "Vanuatu",
                    DialingCode = "+678"
                },
                new CountryDetails
                {
                    CountryCode="VA",
                    CountryName = "Vatican City",
                    DialingCode = "+39"
                },
                new CountryDetails
                {
                    CountryCode="VE",
                    CountryName = "Venezuela",
                    DialingCode = "+58"
                },
                new CountryDetails
                {
                    CountryCode="VN",
                    CountryName = "Vietnam",
                    DialingCode = "+84"
                },
                new CountryDetails
                {
                    CountryCode="WF",
                    CountryName = "Wallis and Futuna",
                    DialingCode = "+681"
                },
                new CountryDetails
                {
                    CountryCode="YE",
                    CountryName = "Yemen",
                    DialingCode = "+967"
                },
                new CountryDetails
                {
                    CountryCode="ZM",
                    CountryName = "Zambia",
                    DialingCode = "+260"
                },
                new CountryDetails
                {
                    CountryCode="ZW",
                    CountryName = "Zimbabwe",
                    DialingCode = "+263"
                }
            };
        }

        public static CountryDetails[] List { get; }
    }
}