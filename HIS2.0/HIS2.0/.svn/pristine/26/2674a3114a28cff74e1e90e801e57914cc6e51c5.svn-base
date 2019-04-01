using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ts_mz_rizhi
{
    class PubFun
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public enum KindNFO
        {/// <summary>
            /// 增加
            /// </summary>
            Add,
            /// <summary>
            /// 取消
            /// </summary>
            Cancel,
            /// <summary>
            /// 修改
            /// </summary>
            Modify,
            /// <summary>
            /// 保存
            /// </summary>
            Save,
            /// <summary>
            /// 查询
            /// </summary>
            Find,
            /// <summary>
            /// 初始化或打开窗口
            /// </summary>
            Init
 
        }
        /// <summary>
        /// 类型（增加状态、修改状态）
        /// </summary>
        public enum KindStatus
        {
            /// <summary>
            /// 空
            /// </summary>
            None,
            /// <summary>
            /// 增加状态
            /// </summary>
            Add,
            /// <summary>
            /// 修改状态
            /// </summary>
            Modify
        }


        public static DataTable GetDataTable_CODE(object[][] RowItemArray )
        {
             //RowItemArray = new object[][] { new object[] { (byte)1, " 1级", "1j", "1x" }, new object[] { (byte)2, " 2级", "2j", "2x" } };

            DataTable dt = new DataTable();
            DataColumn col1 = new DataColumn("CODE", typeof(byte));
            DataColumn col2 = new DataColumn("NAME", typeof(string));
            DataColumn col3 = new DataColumn("PYM", typeof(string));
            DataColumn col4 = new DataColumn("WBM", typeof(string));
            dt.Columns.AddRange(new DataColumn[] { col1, col2, col3, col4 });
            if (RowItemArray==null) return dt;
            //string[] rows = RowItemArray.Split('|');

            for (int i = 0; i < RowItemArray.GetLength(0); i++)
            {
                DataRow dr = dt.NewRow();
                dr.ItemArray = RowItemArray[i];
                dt.Rows.Add(dr);
                //dr.ItemArray = new object[] { (byte)1, " 1级", "1j", "1x" };
                //dt.Rows.Add(dr);
                //dr = dt.NewRow();
                //dr.ItemArray = new object[] { (byte)2, " 2级", "2j", "2x" };
                //dt.Rows.Add(dr);

            }
            return dt;

        }
        public static string GetSpellCode(string CnStr)
        {
            string strTemp = "";
            int iLen = CnStr.Length;
            int i = 0;
            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += GetCharSpellCode(CnStr.Substring(i, 1));
            }
            return strTemp;
        }

        /// <summary> 
        /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母 
        /// </summary> 
        /// <param name="CnChar">单个汉字</param> 
        /// <returns>单个大写字母</returns> 
        private static string GetCharSpellCode(string CnChar)
        {
            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

            //如果是字母，则直接返回 
            if (ZW.Length == 1)
            {
                return CnChar.ToUpper();
            }
            else
            {
                int i1 = (short)(ZW[0]);
                int i2 = (short)(ZW[1]);
                iCnChar = i1 * 256 + i2;
            }
            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {
                return "A";
            }
            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {
                return "B";
            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {
                return "C";
            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {
                return "D";
            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {
                return "E";
            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {
                return "F";
            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {
                return "G";
            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {
                return "H";
            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {
                return "J";
            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {
                return "K";
            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {
                return "L";
            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {
                return "M";
            }

            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {
                return "N";
            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {
                return "O";
            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {
                return "P";
            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {
                return "Q";
            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {
                return "R";
            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {
                return "S";
            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {
                return "T";
            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {
                return "W";
            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {
                return "X";
            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {
                return "Y";
            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {
                return "Z";
            }
            else return ("?");
        }

        /// <summary>
        /// 返回五笔码
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns></returns>
        public static string GetWBcode(string inputstring)
        {
            string thisletter = inputstring.Trim();
            int letterlen = thisletter.Length;
            string pystring = "";

            string LETTER1 = "ghgdgvatuggunnenkouftgqxnttrtnnmxgtucnladqturugivfryifeqfeofhqg ffmdgcgyyyyyyyuyywwnwwwwwwwwwwwhwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwgwwwwwwwwwwwwwwwww                                                               wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww wwwwwwwwwfwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww                                                               wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwgwwwwwwwwwwwwwwwwwww wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwabwwtdhvaufdffftuffitmgwugwwummmdmmmmjmajppppppppppppduuuuuuuuuuuuuuuuuuuuuu                                                               uuuuuuthntmmmmmmmmubbvvttfrefnvxevnwckffmggffebfgggyhkwfquftdaa ugmxcygwydgymnmtwamwxugnfmcacvtlyhqwkhwwiywwrwtyxnlrylrrdriurufucafgfgttgycfuyfusxdtjcakweonsfgxvrqattuuhyatthdtyaqqqqqqqqqqqqq                                               ";
            LETTER1 = LETTER1 + "                tqqtxaaaaaaaaaaaaaaaaaaaaaaaaaanavflnnfeaxghhmqavqtwgwkswqdddrd dddddddddddddddddddddddidddcvdccngcccffnntcfcnpfnhokvkbkkykkkkkkkknkdkkkkkkktkkekikkkkktkkkkkkkkkkkkkkkkxkkkkkkkukkkkkkk kkkkkk                                                               kkkkkkkkkkmkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkdkkgkkfkkk kkkkkkkkkkkkkkkkukkkktukkyykkhkkkkyrkdkkkkkkkkkkkkkkfkkkkkkkdkkkkkkkkkkkkkfktkkkkkkigkkkfkkkkfkkkkkkkkkkkkkeklkfkkkkkgkkkkkkkkk                                                               kkkkkkkkkkkkikkkkkkkkkkkkkkkkkkkkkkkkkkkkkdkkkkkkkkkkkekkkkkykk kkkkkkkkkkkukkkkfkkkkkkkkkkkkkkkkkkkkkkkkkkkfkkkgkkkkkkkkkfxkkyqkkkkkkkkkkkkkkkukkkkjkfkakkkkkkmlllllllltlllllllllllllcllllllll                                                               llllllllllllffffffdftfffdffjffffffffffxfirffgfifjffffffffffffff ffwfffffufsrffffffffffffffffffffffftifftffbffffmfffrffffsffffffffffffffffffffffbifyfaffgffsffffffffffffffcffffffffffvfffffffiyf                               ";
            LETTER1 = LETTER1 + "                                ffflfffffvffofffffffifffffafffifbfffffffiyfffyffflyffffffffffff vfnffffffffbfffffffffyfbfbnfffffffffffffeffnfswffffffiffgfdffflffffffufhffffflfffnfffffffffffffjetttytcfwqodqqqvqqqqayanndddddd                                                               dddgdddyhuqddcddddddgdctudddndddlxdvvvvvvvnvvvvvvvvvvvvbvnjvvvv vvvvvvqvvvvvvvlvvvvvvwvvvvvvhvvvvvvvvvvvvvvlvvvvvvgvvvvvvvvvvvvvrvvvvvvvvvvvvvvnvvvvvvvvvvvvvvvvvvvbkvvvvvvvvvvvvvvdvvvvvvavvvv                                                               vvvvvvvvvvvgvxvvvvvvvvvvvvvvvvvvvvvvvvavvvvvvvvvtvvvvvvvvvvvvvv evvvvvvvvvtvvvvvvvvvovvvvvvgvvvvvavvvfvvvvvvvvgvvuvvvvvvvvvvvvvvvdvvvvvavvvvvvvvvvvvvvvuvvvvvvvvvvvvvvvvvdvhivvvvvvvvvvvfvvvvvv                                                               vvvvxvvvbbbnbxbbbbabbyfrnbbbxppppppppppppppppppppppjppppppppppp ppppppppppppppppppppppppppppeyaggfngvfouiwthiidjaiwwdwvgfvvvvvvgvnnnnnncnrnnnnnnnnnnnnnnnnnuttmmmmmmmmmbmmmmmmcmmmmmmmmmmmmmmmm               ";
            LETTER1 = LETTER1 + "                                                mmmmmmmmmmmmmmimmmmmwmmmmmmmmmmmmmmmmmmmmmmmmmmmqmmmmqmmwmmmimm mmmpmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmtmmcmmmmkmmmmmmmmwmmmmmommmmmmmmmmmmmmmmmmmmmmmmmmgmmmmmmmmmmmmmmmmmmmmmmbmm                                                               mmmmmmmwmmmmmmmmmmmtmmmmmmmmmmmmmmmmmmmmmmmmmmxmmmmmmmmvygevaaa grvabnuchtmnmmqymwmmmyvmmuvwmmmwvgjmmmmammmmmmmmfmmmtmmmetmmmmmmdmmmmuumnmmmmfmmmmmmgufxyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy                                                               yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyvmrlslwfwnaaagqxxxuxxxxxxx xxxuxxxxxxxxxxxpxoxxxuxxxxxxxxxnxxnvxvvvyyagmpsgttttttttttttttttttttttttttttttttttttqtttttttttrtnfnntnvnnnyyngnrnntnnnnnnnnnnnn                                                               nnnnnnnndmnnxrwnnnnqnnnnfswnvnnnnnnnnnnnvnnntnnnnnbnnbnnnnygwnn nnnwnnrnnnqnnnnannntntynngnnfnunpnnnnnsnnhnnipnanntnnjnnnngnrnvfnnndnnnnnnfnnnnnnnnnnnnncnpenvnnnnfnnunnnnnnlnnnnsnnbnnnnlinnn";
            LETTER1 = LETTER1 + "n                                                               wncnnannnngnlnntnnnnnfnfnntnghnnnnnyafnndnwunnddttntnnwqnnnunnn ssnfnnnnndnnnnonnnnnnnnpnnnnnnnnannnnannneynnnnnndqninnnnnnonnninnnnnnnynngnntnnnnennnnnnxannnuuqaamamduwiwsgdphkhhhygyyynyyyyy                                                               rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrfrrrrrrrrrrrrrrr rrvrrrrrrrrrrfrrrrrrrrrrrrrrrvrrrrrrirrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrr                                                               rrrdrrrrrrrrrrrrrrrrrrrrrgrtrrrrirrrrrrrrrrrrrrrrrrrrrrrrrrrrrr rrrrtrrrrrrrrrrrwrrrrrrrrrrrrrrrrrrrrrrrrrfrrrrrrrrgffrrrrrrrrrrrrfrluryrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrlrrrrrrrrrr                                                               rrrrrrrawrrdrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr rxrrrrrrrrfudfgnfwrhqncwghtwfdwugmwuwmcjjoduicjtnmmubkhaqftutllwufwwyyyyyyyyyyqckvfalrnqlafvaoqrxnyyyyyyyygyyy";
            LETTER1 = LETTER1 + "yyyyyyyyyyyyarmjj                                                               jjjjjmjjjgjjjjjjjgjjjjjjjdjjjjjjjjjjjnjjjjjjjjjjjjjjjjjjgjjjjjj jjjvjjrjjjjjjjjjjsyjjjjjjjjjjjljjnjjjjjcjjjjjjujjjjjjjjdjjlfjjjjjjjjjjjjujjjrjjjjdjjjjjjjjjjjjkjjjjjjjjjjjjjjjjjxjjjjjjqvfjuajw                                                               jfuweeemeeeelyeaeeaeeeegfsssessssssgssssssssssynssssssssssssgss sssfswssssxssssssssssssssssssssscspssafsssssssfsswsspssssssssssssssssssssssssssssigsfsdsssssstswsssussssssssssssssssvsssfssssss                                                               sssssissssssssssssssssssssssssssssssssssssspwstsssspssssssssshs sssssssstyssssasssdssssgssssswssssssysssssssssssbassssssssssywsssssssssssswfssssssssssswsssssssssssssssssswssssssssssssssscssss                                                               sssssssssossssssussussssssssssssssfsssrssssssssjsssossssssssess ssystsssssssssksssfssssssssssssslswsssssssnsssfssssfsssxsssssssssssssssssswsssssssssssssssssss";
            LETTER1 = LETTER1 + "ssssssssssssssssrssssssssssssssss                                                               dssssssnsssssssssssssssssssssssssbssssssssssssslswsssssssssssss ssssssssssssssssssssodsssssssssssssssslsssssssssssgssssssssssssssgsssssbsssssssssssbssssssssswssssssssssxsssssssswssssjwqvbrylu                                                               ftwhyxgcocqqsammswyrtaaahuthffvouwllfwcahhhhhhhvhhhdhhdwhgggggg gggggggggggggggggggggggggggggggyfaqffqfvylavqafxtfxlqttxiltnwtbttttgrttcttjttdjjcktfucyktatlqrrrrrrrrrrrrcyniiiiiiiiiiiiiiiiimi                                                               iiiiiiiifiiiiiiiiiiiiiiipiiiiiiigiiiiiiiiiiiiiiiiiisiiiiiiiiiii iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiitiiiiiiiiiiiidiiiiiiiiiiieiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii                                                               iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiwiiiiiiiiiiiiiiiiiidiiiiiiiiiiiii iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiitiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii";
            LETTER1 = LETTER1 + "eiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiioiiiiiiiiiiiiiiii                                                               iiiiiiiiiiiiiifiiiiiiiiiiifiiiiiiiiiiiiiiiifiiiiiiiiiiiiiiinixi iiiiiiiiieiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiieiiiiiiiiiiiiiiiiiiiiiiiiiiiiwiiiiiiiiiiiiiiiiiiiiiiiiiiiitiiiiiiiiiiiiiiiiiiii                                                               iiijiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiit iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiixiiiiiiiiiiiiiiiiriiiiioooqoooofvaowoooooooooooaojooooooooooooooqoooonooooooqwoogtooooodfoo                                                               obooooooogooroooooooooookwovoooynoorboooouoooootobyoooooooooooo oojoooojooooooooooooooofoooaoooojhooooooooooovooooooooooooooocoootocoooooooooooooooooooootooodooofxoooooooooooootfoooooooosooos                                                               oooionoowoowoooooooooooooooooyooooofooohoooaooooooooooqoooooooo ooooooyooooooeereeelwqgnnnnnnhttttttttttttirrrrrrrrrrrrrrrurrr";
            LETTER1 = LETTER1 + "rytrrrrrrrfrrrrroryrnfrrrrrrrrrrrwtrwdqqqqqqqqqqnwqqqhqqqqqqqqqqq                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       ";
            LETTER1 = LETTER1 + "                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";
            LETTER1 = LETTER1 + "                                                                                                                                                                                                                                                                                                                                                                                                                              qqqqqqqqqqqqqqqqqqqqqdqqqdsqqqqjqqqqqqqqqqqqqqqqqqqqqqqqqmqqqqq qqqqnqqqqqquqqqqqqqqqiqqqqqqqqqqq                                                                                                                                                             qqqqqqkqqhqqqqqqqyyyggtggggggggggggggggggghaggggggggggggggggggg ggggggggggggggggggggggggggggggggg                                                                                                                                                             gggggggggggggggggggggggggggggjggggggggggggggggggggggggggggggggg gggggggggggggg";
            LETTER1 = LETTER1 + "gggggoggigggggfgggg                                                                                                                                                             gggaggggggggggggggggigggggggggggggggggggggggggggggggggggggggggg ggggggggggggxggggggrrfrgagqwypgqg                                                                                                                                                             dcqkdqgittcytguotukuagotqyhhahijtyuggttqjtmlllrljeyhlllgoyillyl yflrllwllolvwllllglvilgllllvlllll                                                                                                                                                             gjlgncfuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu uuuuuuuuuuuuuuuuuuuuuyuuuuuuuuuuu                                                                                                                                                             uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuwwwqwrrrrrrrrrrrrrfrrr";
            LETTER1 = LETTER1 + "r rrrrrrrrrrrrrrrrrhhfasfuhqhfyfhegkbfrkkyruatadebarpwrjmepejmmggrpwtniarrkktwucrkardfflwrsdrwmrtggrrtwstrrwuulxddssexsdjqwyaeqyv                                                               xdtdqiigfivaxvlatwhdfiwaxhhhhhhhhhhhhhhhhhhhhhhlhhhdhhhxhhhhhhh hhhhhhhhhhlhwhhhhhhhhhhhhhhhhhlhhafwwqprrjeqosddrudumqwqttopdastmxgdkugtxkttgaaxxxtyuuuunnnnnbalxmywyyuuuysheguukusyiiprrusgtqo                                                               thhhhhhlhhnhhhhhhhghhhhhrhhhhfhhlhehhahhhhhhbhhhhhhhhhhhhhhhhhh hhghhhhhhhhhhhhhhhhhhhxhhhhcccccxuugarrqiffrqtwrteeiicrhkpfidhtunrqfsfmhkeeaahcggnnoatwiarosgadtwminkrcaasdrpwuyrherrjqyxquuyjq                                                               qttttttddddddkddddddddddddddddddddkddvdddddddddddddddddddddkddd dddddddddddddrdidddddddddaddddaddfiitwedijkwfrqfkivkolrrrtisadijnibfprtfsdktttiybkctkurjinxcbhwnffroyujmprslktttwxhntpbsdkqqibs                                                               ddidddddddddddkdddkdddddddddkddddddddddddddddd";
            LETTER1 = LETTER1 + "ddddkdddldddkdddd ddddddddddddddddddddddddddddddgdddwfrqtrkpswtkkupmyuwkorqtdssdixdnxuadhtuuyhgmubatqwwuostwktprmweuoinsdfdrrrrqrdturdkgwfggwwwtv                                                               dddwdddnddddddwdddddddddldddsddddudddddddppppppppppppppppppfphp pppppppppppppppppppppppppppppppppcbrmuurejrwniyxniriasvrkwqpngtnuuttrkowthwcfwimttqinvryfatuuuxfridhmgrjwqynuindkmunrkqykwdjryc                                                               ppppppppoppppppppptpppppppppppppppmhtttttttottttttttttttttttttt tttttttuttttttyttttttttttttttttttshkqshqpytatanfswnuiqrubggufhgtqyfhmsqeyivutqwoxfubcfkkyglqrrrkqdftmktmnbjmtwpyvgdrjkqldqbqqif                                                               tyttttttttttttttttttttttyfttttttytttqtxtttttttttttttttttttttttt ttttttttttpppppppppppppppppppppppavltwtuigamttsdqtmorramqqifayeybvwyxyadkneaykeyixaskrwxfsiodwwnodfsjmqmuotuxydmwgfgeqrrlmrtwwe                                                               pppppppppppppppppppppppppppppp";
            LETTER1 = LETTER1 + "pppuuuuuuuuuuuuuuuuuuuruuauuuuuuu uuuuuttttttttttttttttttttttttttttiippxgrlwwweeyyfgsmtwwwweqpybvxkkkynsquifasstefdtnummqrexmistryyuorqttssraweupaasjubqwtxskdgyu                                                               ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt ttttttttttttttttttttttqttttttttttfbsaaaadwtwpxaaraaqqiaqfsmqdaktwibvfdjmweddlytrkprptrnsuppctqrnixiyqgffdjqulrywsskkwlisqyljyfk                                                               tttttttttttttttttttttttttttttttttttttttttttttttttt tttttttttttt tttttttttttttttttttttttttttttttttmbirypcsnafwipbkpfrrjnnoiidstfkyyfvdkikkaasttwwweuiifpplklutqnkystnlkojiipxxkwqkdwrktqgfadjqoi                                                               tttttttttttttttttttttttttttttttttttttttttttttttooooojooooqooooo oxooooooooooovoooooooooooootoooooxhkrgiyakwqigawystnifcgsgxrkkuuoipxanadjtrmnojmnydritnjlvndfgjmtwoiyyxaqvfiipiwoaaafwpffaslttt                                                               ooooooooooooof";
            LETTER1 = LETTER1 + "oooooioooooooonoooooboowaboxxxxxxxxxxxxxxxxxxxxxx xxxxxxxxxxxxxxxxxxrxxxxxxsxxxxxxxeqyiycvxxfsgltwequivvxrminarutwwynippyyvnbvxxfsgwplagslqwtwllvgjjituuuycvxasgddrrtwuuasjkmmqtw                                                               xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxwdxxxxxxxxxxxxxxcxuxxxxxxxx xxxxxxxxxxxxxxxxxxxxxxxxxxxxdxxxxwtwqiiivwuuuixauuyaubasdweuuicvkrqtweqqqxxvfsllkprrxttbffassrhuixqvaaalwwuynmtrqwipjqwyfagsroi                                                               xxxxxxxxxxxvxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxaxxxxxtxxxxxxxxx xxrxxxxxxxxxxxxxxxxxxxxxxyxxxxxxxncadahjqynooxfajcgfaqtuuuuuoprpxgdqqvidfhvvtyuarquncanktiibrrahkkqwqnonrkvwuuxrrrrweiuyxfaqpvm                                                               xxxxxxxxxxxxxoxxxxxxtxxxxxxxxxxxxxxxxfxeexxxxxxxxxxxxxxxxxxfxxx xxxxxxxxaxxxxxlxxxxxxxxxxxxxxxgxxwuivckkhkgrsmnffafdrynorryofrotfassdjtfksidypyhkvvfkpabrrkrpskpasypdfrkeftwnpfatqsdhjufdmpadrw                                                             ";
            LETTER1 = LETTER1 + "  xxnxxxtxxxxxxlxaxxxxxxnxxxxxxxxxxxxxxxxxoxxxxxlxxxxxxxxxxxxxxxx xxxxxxxxxxxrrrrrrrrrorrrrlyhlrrlmqnifjrlrryufrkjeukaggassrtuuiyrjnxoigsqyyyirapfwvsoiaqfqadlwcreoissudttttqyigsjqpaagsgddddtwww                                                               lplllllllllllllllllllllllllmllllllllgduguuuuuueuuuuuvuuuiuuuuuu uuuuuuunnndnnnjsvnnnnnfwqmvwnpnmnuuoivlgkwbalqynipweqyoxouiiygljjyyrbwuopbibrqyogggiqgsdfjwqiuwyrgafhqwuuvbmwkwigsdqqyuisuddktp                                                               kpnnnnnnsnnroffwhlffffffddmdddgddddddddddddbbbbbbbbbbbbbbbbabbb bbbbutbbbbbbbbbbbbbbbftbbbbbbbinbbdrbsortibahhyorhhqsdfkmyipvbnckqwynnxhrtyixyyyiqtrlrlwwixyajllqtcpaicxvygdjckkkfngfdehqyiajni                                                               uygvyeepweeeeeekeeeeeeeeeeeehedeemeeeeeeheeeeeeeeeqeefebmeeleev eeeeeeeeeeedeeemeweeeeeeeeeeeeeeeyaayynaqaqtcqqajmeqtgsssfoinvqtujpvvuuwaasjqqsbhsyyoyxoteipppshxjqqvxdarhatiyvagnrltnujjkqqwyr                                             ";
            LETTER1 = LETTER1 + "                  eeeeeeeeeaeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeoeeeyeeeeeeeheeeeeef meeeeeeeeeeeeeeeeeeeeeeeendeeeeedaaseyyyrgalliipbycartyvxaaaaashhttwkkqvvxrevddflcgrenuikqmvcvfwinrwaeuiarrdrrwvsqnrbakqqiwsqup                                                               eeweeeeeeyeexaeaananttwtttggfggfqtvwwwawwttttwwwttntttttttttttt tttttttttttttttttttttttttttttttttrirrqxeipgvvvvjhurnoykaaaakwikkrmngrrttiisitthluuryuderkqopkikefdmbswikwdryifasdteeerdfdfrrngl                                                               ttttaumbnaaaaaaaaaaaamaaaaaaaaaaaaaqaaaaaaaaaaaaaaaaaaaaaaataaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabakeuhauwnntwtcsissrurhwkbrfaagwuynfihidrrourqwaaaafsluiyjiaasdgauiiiasdhlmeyyppcfmtwyddkrtyiiyr                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaahaaaaaaaaaaaaaaaaaanidrqqtttwyflqquikiylmquskeufaxrsqynshtwaaramwpaaenpqwudgaarwpiglrwqiajrnxyygptrrgfluifajmtnci                             ";
            LETTER1 = LETTER1 + "                                  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbhfflassrwuuducroufasdipvqomiyfrkyqrxartwwvfwyvvxrwjaaaagoipxprcmajwbvdeitplbagquiaxriaeqppdc                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaawackfrcrvgqiswadqqixwkqtjgasmmopubrmeuiyxfwuijhiisrtoaquikvxdmjtwfrtnipydjkwtivxpipvajnifttttx                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaagaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaidtecjrqyiynnfdrjwwqpyktwncvaffasgrrrrjkktwwtqqynppynrupdrweuuassgrlhwinnmyyajjlltvnsssgdjjyoi                                                               aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaavndryejsrfcdyihtkhkeyduoarkltnxgdfklwwqnswwwupyyrtrkaswggswuipyvsatkbbxmdmtubbbrtaskxgfqrfwpvf             ";
            LETTER1 = LETTER1 + "                                                  aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaagaaaaaaa aaaaaaaaaaaarvhhhhhhhhkuhghhahhihqrkkearcdsddifrwuifsuiyyftpdrkmifriieyowtifiriixasiibydtaeuusjkqrjkkwfkniungifltntertvhkmqmdko                                                               jjjjjjjjjjxjjjjjyjjfjjjjjjjjjjjwjjjjjjjjjjjjsjjjjfjjjjfejfjjwjj jjjjjjjjjdjajjjjjjjjjjjjjjjjjjtjjitwyyrtcsshmqmusrtxuwruthtpltwinfkqilrtejpvggnrreqbccserkrkjivgpgqgyigfvopdrjrnpvdeigysmtjyyyd                                                               fjajjsjjjfjjjjejjjjajjjjjgjjjgjjjjjjjjjqfjjjjjjjjjjjnjjjjjjyjjt jjjjjujjjjjjtjjfjffjjjscjffjjyoeymtqffslknyixaatwwnxfakllktwiynnbuijyuxktyukwwrjiptfariakqqiynfasgkxggrtrwwfdfjtqtnyaassddjkkqt                                                               jjfjjjjnjbaywfjjjnnjjfjajjjjjjjjjjgjjfjjujjjjjjjdjjjjjjjjfajjfg fjajljxjjjajhjjjjjjjjfjjjjasjtjdjttqteqnooiinsdynvfqitbcxhjafljmwqgddkrqtwqxdjttuixvjbgfeequpbbxsdqttyixupyskyaaswtqadfikkqi";
            LETTER1 = LETTER1 + "pij                                                               ubjfjjuejtjyjjjjjfjjgxijaytttttttvttttttttttttttttppppppppppppy pppappppypppppppppppppdpyppppppppifsiktushjjafrraweypsrqniiynaaqruunnwtjeqniggggtsfsnvkqeqidcwwuskqtpxfdfhketyaswvyynvvxxlkpeyy                                                               yppxyppppppppppppppppqpppyppppprypnpvpypppppppppyppphrppjpppppp ppppyyppppppeppppypppbptpyopypppptuhxaaipftkttqyvcvgiyybndralkuaajmtiakgygkuoifgdjmtyuuoidrhtidfadddkuopycgmmtsrwuuibrwuusirevg                                                               ppfypnppppyppppppppppppppppppppppppppppppppppppppppppuppppppppp pgssssssssmcimfmttegnpnhqirifmfvgraepyvkeasiskbwjubdrokjeyigfarqwwyagktwexipvxsjwnncnarjkmwteqxuyyuunyuiyyyynnnxaalrubvkqipqvxb                                                               othmwakfuumpofhlatwuehumghgapfammqqrqqqqqquqdqqqqqqqqqdqqqqwqqx qqqqqyyyvyyyyyyyyyyyyyymyyyyyuyyyqasmyyxaaaajqyejxdjkrweuyykjkiiyccexwwndmmqqiiseddwtycxgiggshjwwwwqniibcvfg";
            LETTER1 = LETTER1 + "mtpyngfadkjkmtwwqyi                                                               yyyyyyyyyyyyyyyyyyyyyyyyyytyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy dyyyyyyywyyyyyyyyyyyyyyyyyyyyyyyyippcccqipfffdrllklqixfadqbjxfkqrtenudfkqbcfasjueadvffppfgdkrltmeagooagjickktroogrmimtfnumrkisl                                                               yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyhyyyy yyayyyyyyyyyywyyyyyyyyyyyyyyyyyyyquhssktoyryppwphtqoigllmnashhuixsuuixiisdmmweubrjrifjliyvyrrrlfqayigafsdghqwsuyfrqbarhtqqngrgg                                                               yyyyyyyytyyyyyyyyyyyyyyyyyyyyyyyeyyjyyyyoyyyyyyyyyyyyyyyyyyyyyy yyyyayyyyyyyyyyyyyfyyfyyxyyyyyyyymuuyasfkjteeipxbfsgrwwfrhkkxxfrrgglmmrtttrquiipkkkqyxtetwwtmyiyxlevkqpncgsjrqyyetofrhkyasejmqt                                                               yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyykyyyyyyyyyuyyyyyyyyyhawyyyyyyyyt yyyxuyywtwyyyyyyyyyyyyyyyyyyyyyyywipcrrrfdlrmtsyuuruusqwgbxyurrhhgaskuoiuuuuiibhwoibtipdskpx";
            LETTER1 = LETTER1 + "uxqfdrtkyypybxqtksjluujdwswwwy                                                                    twwwwwwewwwwwmmwgagbmbbbggguggggggggghgggegggfggggggeeeeeeeeeee eeeeeeeeeeeeeeeemfcqmaammmwwmwxgrfgggagggbggghjtxttqrqttvttiybenhfgffdddddddddaaaaaafhjqqcdmmgdopasdwatmmwwwwwwwwwwwwwwwwwwwwww                                                               fhamhgkcmlwmmxmmmqlfmwmmmusmhmyhmhmhmppmmmhhsfmmihmyafmmmmpmrfh mvmmhwhgmmfemhmmpamajmmfgmyhmtdmmwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwttwniuuuqqqqqmmyuyuyyyyyyyyuuuu                                                               mymuahlqmdmhmuhcmmmyfffffffffffffffffffffffffffffffffffffffffff fffffffffffffffkkkkkkkkkkkkkkkkkkupppyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyybbbbbbbbbbbbbbbbbbbbbfayyqygguo                                                               kkkkkkkkkkkkkkkkkkkwkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk kkkkkkkkkklkkkkkkkkkkkkkkkkkkkkkkqcggrwqqpgktqeroasgautubfdqqdqvylbjlvohpbiq";
            LETTER1 = LETTER1 + "ccccwgwygyhffffffffffffffffffffffffffffffffffffffff                                                               kydkkkkkkkkknkkakkkkkkkkkktkkktkkakkkkkkkkkkttttttttttttttttttt tttttttlllpllllllllllllllllllllglffffffffffffffffffaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa                                                               lllllllclllulllllllllllllllllallllllflmlllllllllllllllllillllll llflldlslllllllllllllllllllwllfllaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa                                                               llllllllllllllllllllllllwlglxllllllllctugebuuhueuumskegevftmffb ntgegdydgkhnajyqpflmdspggqfthsrgcaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaydddyendddddrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr                                                               yglilwsdaccrmwyhjffajdunujhypkmfnfqvblrnfucxuucgghtknafsnckkdta lywfttttqlgsnmfvqfywrpfgodqnglffdrrrrrrrrrrrrraaaqkkkkkkkkkk";
            LETTER1 = LETTER1 + "kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkqqqtqvttlqqvyuuxntipkquwtxtcdntqiamnuwnqadrqclundtojqqqqpdpcnitywfrttftytdgkggyggfwmqggmbusvtuxhqhnnafwtpwwxxvyptdygqtwxkyyaeyqngfqjqtwkvqueuqouhokwmayffydaaqtakkukkkkkkkkkkkkkkkkukkikkkikkkkkkkkqkkkspkkkkxkdkkkvkkkkkkkkkkkkskkkkkkkkqkklllllllllllmmmvmmmoqjjjgddbggpbqfyjdhshhbsjqghfqqqqsqpesqqccbqhtvjqgrhgtcktgqphtqmtgswsssssssssssfssssssssssssssssstssssslssotsusjsssdussssssssyqssssswsssspttfqqqqqqqqqcqqgqwqqqqmmmmmmmmmmmmmgnmymmmmmwmmmmmmmmmmmmmmmmmmmmmmmgmmmmmmmmmummutltttttfttttteqqrqqqqqqqqqqqbqqqqqqqaqfadmqnbsdmqvqshqcdxfuhklgqqfutcevqqvqmqqqfqqrftdkqqgubsashqqqqqqqqqqqqqqqqgqqqqqqqqqqqququqqquqqqqqqqqcwqmqqqqqqqqqqoqqqqqcqqqqqqqqhqqqqqqqkqqxqqqqqqcqqqqqqqqqqqqbqqnqqqqqqqqqqqqjqqtqqqqqqqqqgqqqqqqqqqqyyyyyyysyqyqyyyyyncvnnnndnndtncnninnnnnnunnnngnnqstbqwvfqtyoqiqidmqqqfagummgrfgkgtkfgggexxplfqdjsxjqqmqnjdtqqoeqqqqqbqmqcqqqqqqqqiqqqmqqqqusqqqqqqqdqqqqqqqquqqqqrfqjqqqqqqpqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqnnannnnnnnn";
            LETTER1 = LETTER1 + "ndjnsnqnnmnnnqnnnnnftnngbuuuuuuuuuuuuuuuuquuuuuuunniiiseiiiuiqtiiiibiiiiiqiiiiiiiiieqsjqqqesqccqfjftqtjoqfuuuwcqqwbcfifqxyyjijrjijqjqfjhwqujgwgquahjqqqqqqffqrqqqaqnqquqqqqqqqqfuqquqomqqqriqqqqqqwqqqqqqqqqfqqqqdqqtrqqyqqyqqqqqquqaqcqqqqqiqtqqqqqiiiiiiiiiiiiiiqiiiiiiiituiiqiiiiqiiigjgiyiiiiiiiiiiiiiiiiiiiiiiiiquiqiiigiiiqtifiiiiibiiiiiqityqqyktkgsuaiqqfitwwjqfyqvmbvkfqtqdhqnycqvfqqqclgutlpkqqyddqjqgqqgqqqqquqqqgqaqqfqqyqqqqqqqqtqhqqqqppqqqqquhwqqeqqqqaqqaqqqqqdaqdixqqqjqqqqqqqwqrqqqqsqbqxqqvqqtiifiiiimqiciiisgqpmxppyppppppvayeatmttgfggqtcgfiqcftmvasunqyjqjohqepvcqxxnnscmnnvvvxthxhvtvvvqmhsqqqkququwwuubgsqcnqsdqknqqodwqptqyqyybqqcqcveququqqqumqwawdhqqqquqqqtqqqgqqqqtqqqqqqrcqqcpqqqqaqqqqqqqqqqmqtqxqiqqovwqhqqqqftqqqqqqqqdjqsqqqqpqqqqqqqqnqqqqqqdvqvvvcvvuvvvyuvtvvvviqvsltqjcuvqvvcyvvtvbfvvvqvvvvqlvvdqlvuoooccxccvccqctcxccbcqccqqcscxxxdxojlkfqtfusdgsyfqfpqejdqqgpgsqskrrxdqmmdqdfmggkddqoblhyqcyqsoeukswqqxqqqqfqfqqqqqfhqhqqqbflymqqqqqiqqmqcmqqqqqqqqmgqsqeubuqqqqquubqjqamqqseqhqqaqqqqqsqqqqqqq";
            LETTER1 = LETTER1 + "blgqqxxxqxcxtsuckctxxqxyxyxxqxxxexxxyxqyxxtxxtqxcqxxuxxxlxfxxaxxqdvvjogdgcjtyjggdcaggggsqqngggprgrguuoijfedqtafqaatjjqpffpyoyydgoexpkheqdggggaaqshintjqqnunhuttjkhqqqqqmqyqteauqqqeqqhqcqtqfflqheqqqsqaqejdqqtqqjgquuqqqqqqyhytbjhqqqrqqfqqeqqbqkoqbqqpqqqvqdqqqqqaaahgggkjgpugpfgggdgqmgwjffsbsqycsussdjduqcdsqssqusjsssssseuausnnnssssmsscqycjmsrushsrtsshhstlsqqrqtchihtbcqqtqksfkrgfrpjrrrajyqccqqdqydcrqyyudtamgtqyqpddaqhtqqcqeqqjqqqsupodkumasauubyuadtuqqwcuuuwawuuqujuqulafugffaaptajutqaauutuujufjqtuuuobuuccguuufluuquqdqvhujhshsfcclqtjuqdquslssusssdptuqssstlpwsqnqsbgcejcsskscsbnquvpfgggejhtqgxaueblllqcllldclelmccqquyqftmdquiqiiqtfqtkeqbujqcqqqqogttjmdqwncycqqtqqqtaqedbbbtvqqtunungqqqqwouqvvuecpatuuuqfqhumbbbbbbqlqesbbwccdfcbkdqxjmbmcxbpqbdqcbbucbqmbjqmcbbbbvbqbbbvbhaklmoggwihudqkqqdqaacukqmqeqjsjjjhqtqjqafbjjjqqqyjkanjjjjqcgqmrhuemcfqrusqajwucqjummptddgagllxfqdpthjwdqwhqpbqircqglajfvqttdqqqmgftvstcqpanqqgqlbtttrmocleqqqfqqcbcbbscddbbqvckckebbyeanubbebroawanqffomvwutqiqqjyvqbqfqwwqqqfcqyyvfwftedh";
            LETTER1 = LETTER1 + "hdqgfgaftfffuacfftftfcpqqowtsjqqwfurjqrrvrfqncctepevplqufmedqlcprpokmewetequueuuujekejajqsfeyeexquuuxxqqejqkteeimmtctawhahhtkuqtactcqcqdweddqwqmthdnegrrcdosjqoxquoqdqamaiirwqqpcscqfqdajghhfudfltyufaylddqalhullwvdvhdodsddhgdccjdcacamdmojumqsucutaqqeaeaapxchkeaeqdoqqqyaopdalaahsghqahwqtqttymhnumujyoqyulaquqqvtjougcfuhcqcfohfhhsjqwunmomuaohyhhxxuxqqyqypjqcpqpupqqcjpqqljvuvtvfqmpjqqmqcqqqhuphyhvqqcwcjgtpprcwqcqcwssaqptaqqpfifqjfcekdqlqwwvtchhqnnuquotflqmcttthhlqqqlqqttdququujyhuqyqqciqymmlcqjcqyqctqrdqfpyytqltcdlpplqqtdgcfxtrkckoseruutqkctbqffftqttvktctcddsctcqcqrrqttukqyuqctfcydmmqqwctqpqhtuhfqhfdqeeqvyqhtdthhcccdgqqoqqychqqkpqquq";


            char[] c = thisletter.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {

                byte[] sarr = System.Text.Encoding.Default.GetBytes(c[i].ToString());
                if ((int)sarr[0] > 128)
                {
                    int QW = 254 * ((int)sarr[0] - 129) + (int)sarr[1] - 64 + 1;
                    if (QW < 1)
                    {
                        pystring += "?";
                    }
                    else
                    {
                        if (QW > LETTER1.Length)
                        {
                            pystring += "?";
                        }
                        else
                        {
                            pystring += LETTER1.Substring(QW - 1, 1);
                        }
                    }
                }
                else
                {
                    pystring += c[i].ToString();
                }
            }


            return pystring;
        }
        private static string fill(string c, int leng)
        {
            string str = "";
            for (int i = 0; i < leng; i++)
            {
                str += c.ToString();
            }
            return str;
        }
        private static string space(int leng)
        {
            string str = "";
            for (int i = 0; i < leng; i++)
            {
                str += " ";
            }
            return str;
        }
    }
}
