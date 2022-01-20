using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.DTOs;
using Segregare.Repositories.UnitateRepository;
using Segregare.Repositories.ClasaRepository;
using Segregare.Repositories.ScoalaRepository;
using Segregare.Repositories.UnitateIntrebareRepository;
using Segregare.Repositories.MonitorIntrebareRepository;
using Segregare.Repositories.MonitorRepository;

namespace Segregare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitateController : ControllerBase
    {
        Dictionary<string, double> ProcentRomi =
              new Dictionary<string, double>(){

{"BT:BOTOSANI", 1.17},
{"BT:DOROHOI", 1.54},
{"BT:BUCECEA", 0.19},
{"BT:DARABANI", 0},
{"BT:FLAMANZI", 2.3},
{"BT:SAVENI", 2.61},
{"BT:STEFANESTI", 8.9},
{"BT:ADASENI", 0},
{"BT:ALBESTI", 3.52},
{"BT:AVRAMENI", 0.13},
{"BT:BALUSENI", 5.01},
{"BT:BLANDESTI", 0},
{"BT:BRAESTI", 0},
{"BT:BROSCAUTI", 0},
{"BT:CALARASI", 0},
{"BT:CANDESTI", 0},
{"BT:CONCESTI", 0},
{"BT:COPALAU", 2.12},
{"BT:CORDARENI", 0},
{"BT:CORLATENI", 0},
{"BT:CORNI", 0},
{"BT:COSULA", 20.58},
{"BT:COTUSCA", 0},
{"BT:CRISTESTI", 0.97},
{"BT:CRISTINESTI", 0.08},
{"BT:CURTESTI", 0.22},
{"BT:DANGENI", 0.1},
{"BT:DERSCA", 0},
{"BT:DIMACHENI", 0},
{"BT:DOBARCENI", 0},
{"BT:DRAGUSENI", 0},
{"BT:DURNESTI", 0.35},
{"BT:FRUMUSICA", 0.97},
{"BT:GEORGE ENESCU", 1.19},
{"BT:GORBANESTI", 0},
{"BT:HANESTI", 0},
{"BT:HAVARNA", 0},
{"BT:HILISEU-HORIA", 0},
{"BT:HLIPICENI", 1.17},
{"BT:HUDESTI", 0},
{"BT:IBANESTI", 0},
{"BT:LEORDA", 0},
{"BT:LOZNA", 0},
{"BT:LUNCA", 0},
{"BT:MANOLEASA", 0},
{"BT:MIHAI EMINESCU", 0.07},
{"BT:MIHAILENI", 1.93},
{"BT:MIHALASENI", 0},
{"BT:MILEANCA", 0},
{"BT:MITOC", 0},
{"BT:NICSENI", 0.27},
{"BT:PALTINIS", 0},
{"BT:POMARLA", 0},
{"BT:PRAJENI", 0},
{"BT:RACHITI", 0},
{"BT:RADAUTI-PRUT", 0.09},
{"BT:RAUSENI", 0.5},
{"BT:RIPICENI", 0},
{"BT:ROMA", 0.12},
{"BT:ROMANESTI", 0},
{"BT:SANTA MARE", 0},
{"BT:SENDRICENI", 0},
{"BT:STAUCENI", 0.19},
{"BT:STIUBIENI", 0},
{"BT:SUHARAU", 0.1},
{"BT:SULITA", 1.34},
{"BT:TODIRENI", 1.38},
{"BT:TRUSESTI", 1.72},
{"BT:TUDORA", 0},
{"BT:UNGURENI", 0},
{"BT:UNTENI", 0.11},
{"BT:VACULESTI", 0},
{"BT:VARFU CAMPULUI", 0},
{"BT:VIISOARA", 0},
{"BT:VLADENI", 0},
{"BT:VLASINESTI", 0},
{"BT:VORNICENI", 0},
{"BT:VORONA", 0},




{"BV:RUPEA", 6.83},
{"BV:CODLEA", 5.16},
{"BV:FAGARAS", 3.48},
{"BV:ZARNESTI", 2.57},
{"BV:RASNOV", 1.78},
{"BV:SACELE", 1.07},
{"BV:PREDEAL", 0.44},
{"BV:BRASOV", 0.33},
{"BV:VICTORIA", 0.28},
{"BV:GHIMBAV", 0.21},
{"BV:DRAGUS", 0},
{"BV:FUNDATA", 0},
{"BV:HOLBAV", 0},
{"BV:MOIECIU", 0},
{"BV:POIANA MARULUI", 0},
{"BV:SINCA NOUA", 0},
{"BV:AUGUSTIN", 49.19},
{"BV:ORMENIS", 41.95},
{"BV:MAIERUS", 38.97},
{"BV:TARLUNGENI", 28.88},
{"BV:BUNESTI", 25.2},
{"BV:CATA", 21.88},
{"BV:RACOS", 20.41},
{"BV:TICUSU", 18.94},
{"BV:COMANA", 18.6},
{"BV:HOMOROD", 18.02},
{"BV:TELIU", 17.51},
{"BV:APATA", 17.2},
{"BV:JIBERT", 12.18},
{"BV:VISTEA", 11.01},
{"BV:CINCU", 10.84},
{"BV:BECLEAN", 9.86},
{"BV:SOARS", 9.86},
{"BV:LISA", 7.86},
{"BV:PARAU", 7.68},
{"BV:UNGRA", 7.54},
{"BV:VOILA", 6.39},
{"BV:BUDILA", 6.08},
{"BV:PREJMER", 6.02},
{"BV:HARSENI", 4.8},
{"BV:HALCHIU", 4.69},
{"BV:HARMAN", 4.57},
{"BV:VULCAN", 4.53},
{"BV:SERCAIA", 4},
{"BV:RECEA", 3.94},
{"BV:HOGHIZ", 3.68},
{"BV:SINCA", 3.59},
{"BV:VAMA BUZAULUI", 3.32},
{"BV:FELDIOARA", 3.23},
{"BV:DUMBRAVITA", 3.2},
{"BV:SAMBATA DE SUS", 3.16},
{"BV:MANDRA", 2.24},
{"BV:SANPETRU", 1.6},
{"BV:UCEA", 1.55},
{"BV:CRIZBAV", 1.11},
{"BV:BOD", 0.4},
{"BV:BRAN", 0.25},
{"BV:CRISTIAN", 0.07},




{"CJ:HUEDIN", 11.31},
{"CJ:TURDA", 5.45},
{"CJ:CAMPIA TURZII", 5.06},
{"CJ:GHERLA", 3.5},
{"CJ:DEJ", 1.03},
{"CJ:CLUJ-NAPOCA", 1.01},
{"CJ:ALUNIS", 0},
{"CJ:BELIS", 0},
{"CJ:IZVORU CRISULUI", 0},
{"CJ:JICHISU DE JOS", 0},
{"CJ:MAGURI-RACATAU", 0},
{"CJ:MARGAU", 0},
{"CJ:MARISEL", 0},
{"CJ:RISCA", 0},
{"CJ:SANCRAIU", 0},
{"CJ:VALEA IERII", 0},
{"CJ:CAMARASU", 21.58},
{"CJ:COJOCNA", 20.39},
{"CJ:BONTIDA", 19.81},
{"CJ:RECEA-CRISTUR", 18.34},
{"CJ:FIZESU GHERLII", 16.15},
{"CJ:SANPAUL", 15.37},
{"CJ:PANTICEU", 13.12},
{"CJ:SACUIEU", 13.03},
{"CJ:FRATA", 11.6},
{"CJ:MOCIU", 11.2},
{"CJ:LUNA", 10.45},
{"CJ:CASEIU", 9.49},
{"CJ:SUATU", 9.44},
{"CJ:VIISOARA", 8.85},
{"CJ:PALATCA", 8.7},
{"CJ:CALATELE", 8.34},
{"CJ:AGHIRESU", 7.95},
{"CJ:GILAU", 7.78},
{"CJ:CUZDRIOARA", 7.61},
{"CJ:TURENI", 7.55},
{"CJ:ASCHILEU", 7.37},
{"CJ:IARA", 7.33},
{"CJ:DABACA", 6.42},
{"CJ:BACIU", 6.39},
{"CJ:VULTURENI", 6},
{"CJ:CEANU MARE", 5.98},
{"CJ:CAPUSU MARE", 5.64},
{"CJ:MANASTIRENI", 5.33},
{"CJ:POIENI", 5.18},
{"CJ:FLORESTI", 4.89},
{"CJ:GEACA", 4.8},
{"CJ:MINTIU GHERLII", 4.62},
{"CJ:GARBAU", 4.02},
{"CJ:CATINA", 4.01},
{"CJ:SANMARTIN", 3.97},
{"CJ:BUZA", 3.96},
{"CJ:BOBALNA", 3.94},
{"CJ:APAHIDA", 3.86},
{"CJ:MOLDOVENESTI", 3.5},
{"CJ:CIURILA", 3.45},
{"CJ:CORNESTI", 3.42},
{"CJ:TAGA", 3.24},
{"CJ:BORSA", 2.81},
{"CJ:PETRESTII DE JOS", 2.58},
{"CJ:CAIANU", 2.55},
{"CJ:FELEACU", 2.52},
{"CJ:NEGRENI", 2.33},
{"CJ:BAISOARA", 2.32},
{"CJ:ICLOD", 2.21},
{"CJ:MICA", 2.08},
{"CJ:SAVADISLA", 1.78},
{"CJ:PLOSCOS", 1.71},
{"CJ:MIHAI VITEAZU", 1.49},
{"CJ:UNGURAS", 1.48},
{"CJ:AITON", 1.11},
{"CJ:CHIUIESTI", 1.07},
{"CJ:JUCU", 0.84},
{"CJ:CHINTENI", 0.59},
{"CJ:TRITENII DE JOS", 0.47},
{"CJ:SIC", 0.41},
{"CJ:CALARASI", 0.4},
{"CJ:CIUCEA", 0.39},
{"CJ:VAD", 0.3},
{"CJ:CATCAU", 0.29},
{"CJ:SANDULESTI", 0.22},




{"CT:CONSTANTA", 0.78},
{"CT:MANGALIA", 0.45},
{"CT:MEDGIDIA", 1.52},
{"CT:BANEASA", 6.24},
{"CT:CERNAVODA", 2.23},
{"CT:EFORIE", 3.25},
{"CT:HARSOVA", 5.31},
{"CT:MURFATLAR", 2.49},
{"CT:NAVODARI", 0.89},
{"CT:NEGRU VODA", 2.93},
{"CT:OVIDIU", 1.83},
{"CT:TECHIRGHIOL", 0.4},
{"CT:ADAMCLISI", 0},
{"CT:ALBESTI", 0},
{"CT:AMZACEA", 0},
{"CT:CERCHEZU", 0},
{"CT:CIOBANU", 0},
{"CT:CIOCARLIA", 0},
{"CT:COMANA", 0},
{"CT:DELENI", 0},
{"CT:DOBROMIR", 0},
{"CT:DUMBRAVENI", 0},
{"CT:FANTANELE", 0},
{"CT:GARLICIU", 0},
{"CT:GHINDARESTI", 0},
{"CT:GRADINA", 0},
{"CT:HORIA", 0},
{"CT:INDEPENDENTA", 0},
{"CT:ISTRIA", 0},
{"CT:OLTINA", 0},
{"CT:PANTELIMON", 0},
{"CT:PESTERA", 0},
{"CT:RASOVA", 0},
{"CT:SACELE", 0},
{"CT:SALIGNY", 0},
{"CT:SARAIU", 0},
{"CT:SEIMENI", 0},
{"CT:SILISTEA", 0},
{"CT:TARGUSOR", 0},
{"CT:TOPALU", 0},
{"CT:TOPRAISAR", 0},
{"CT:TORTOMAN", 0},
{"CT:TUZLA", 0},
{"CT:VULTURU", 0},
{"CT:CUZA VODA", 21.47},
{"CT:CASTELU", 7.06},
{"CT:MIHAI VITEAZU", 4.84},
{"CT:COBADIN", 3.84},
{"CT:OSTROV", 3.69},
{"CT:MIHAIL KOGALNICEANU", 2.45},
{"CT:VALU LUI TRAIAN", 1.8},
{"CT:CUMPANA", 1.76},
{"CT:NICOLAE BALCESCU", 1.45},
{"CT:ION CORVIN", 1.4},
{"CT:LUMINA", 1.37},
{"CT:LIMANU", 1.34},
{"CT:LIPNITA", 1.23},
{"CT:MERENI", 1.17},
{"CT:CORBU", 0.79},
{"CT:POARTA ALBA", 0.63},
{"CT:CHIRNOGENI", 0.61},
{"CT:MIRCEA VODA", 0.45},
{"CT:COSTINESTI", 0.42},
{"CT:23 AUGUST", 0.36},
{"CT:PECINEAGA", 0.34},
{"CT:BARAGANU", 0.3},
{"CT:AGIGEA", 0.23},
{"CT:ALIMAN", 0.14},
{"CT:CRUCEA", 0.14},
{"CT:COGEALAC", 0.06},




{"IL:CAZANESTI", 13.24},
{"IL:TANDAREI", 10.86},
{"IL:FETESTI", 5.4},
{"IL:URZICENI", 2.88},
{"IL:SLOBOZIA", 2.77},
{"IL:AMARA", 0.41},
{"IL:FIERBINTI-TARG", 0.34},
{"IL:ADANCATA", 0},
{"IL:ALBESTI", 0},
{"IL:ARMASESTI", 0},
{"IL:BRAZII", 0},
{"IL:BUESTI", 0},
{"IL:CIOCARLIA", 0},
{"IL:CIULNITA", 0},
{"IL:COSAMBESTI", 0},
{"IL:COSERENI", 0},
{"IL:GHEORGHE DOJA", 0},
{"IL:GIURGENI", 0},
{"IL:GURA IALOMITEI", 0},
{"IL:MARCULESTI", 0},
{"IL:MIHAIL KOGALNICEANU", 0},
{"IL:MOLDOVENI", 0},
{"IL:PLATONESTI", 0},
{"IL:ROSIORI", 0},
{"IL:SAVENI", 0},
{"IL:SFANTU GHEORGHE", 0},
{"IL:SUDITI", 0},
{"IL:VALEA CIORII", 0},
{"IL:BARBULESTI", 79.7},
{"IL:BORANESTI", 35.37},
{"IL:BARCANESTI", 16.43},
{"IL:TRAIAN", 16.41},
{"IL:ION ROATA", 12.13},
{"IL:SINESTI", 12.08},
{"IL:ALEXENI", 6.31},
{"IL:ANDRASESTI", 5.97},
{"IL:SARATENI", 5.04},
{"IL:MANASIA", 3.81},
{"IL:BORDUSANI", 3.78},
{"IL:VALEA MACRISULUI", 3.65},
{"IL:MOVILITA", 3.12},
{"IL:COCORA", 2.82},
{"IL:OGRADA", 2.71},
{"IL:JILAVELE", 2.15},
{"IL:SALCIOARA", 1.67},
{"IL:BALACIU", 1.67},
{"IL:REVIGA", 1.5},
{"IL:FACAENI", 1.42},
{"IL:MOVILA", 1.09},
{"IL:COLELIA", 0.99},
{"IL:GRINDU", 0.91},
{"IL:MAIA", 0.81},
{"IL:AXINTELE", 0.79},
{"IL:VLADENI", 0.7},
{"IL:GARBOVI", 0.68},
{"IL:STELNICA", 0.68},
{"IL:CIOCHINA", 0.53},
{"IL:DRAGOESTI", 0.37},
{"IL:MUNTENI-BUZAU", 0.29},
{"IL:DRIDU", 0.28},
{"IL:GHEORGHE LAZAR", 0.22},
{"IL:PERIETI", 0.2},
{"IL:SCANTEIA", 0.16},
{"IL:MILOSESTI", 0.15},
{"IL:BUCU", 0.13},
{"IL:GRIVITA", 0.09},




{"IS:PODU ILOAIEI", 9.11},
{"IS:TARGU FRUMOS", 8.12},
{"IS:HARLAU", 5.78},
{"IS:PASCANI", 1.48},
{"IS:IASI", 0.47},
{"IS:ALEXANDRU I. CUZA", 0},
{"IS:ARONEANU", 0},
{"IS:BARNOVA", 0},
{"IS:BIVOLARI", 0},
{"IS:BRAESTI", 0},
{"IS:CEPLENITA", 0},
{"IS:CIORTESTI", 0},
{"IS:COARNELE CAPREI", 0},
{"IS:COSTESTI", 0},
{"IS:DELENI", 0},
{"IS:DOBROVAT", 0},
{"IS:DRAGUSENI", 0},
{"IS:DUMESTI", 0},
{"IS:FANTANELE", 0},
{"IS:GOLAIESTI", 0},
{"IS:GORBAN", 0},
{"IS:GROPNITA", 0},
{"IS:GROZESTI", 0},
{"IS:HALAUCESTI", 0},
{"IS:HARMANESTI", 0},
{"IS:HELESTENI", 0},
{"IS:HORLESTI", 0},
{"IS:ION NECULCE", 0},
{"IS:IPATELE", 0},
{"IS:LESPEZI", 0},
{"IS:LETCANI", 0},
{"IS:MOGOSESTI", 0},
{"IS:MOGOSESTI-SIRET", 0},
{"IS:MOSNA", 0},
{"IS:OTELENI", 0},
{"IS:POPESTI", 0},
{"IS:POPRICANI", 0},
{"IS:PROBOTA", 0},
{"IS:RACHITENI", 0},
{"IS:ROMANESTI", 0},
{"IS:ROSCANI", 0},
{"IS:RUGINOASA", 0},
{"IS:SCANTEIA", 0},
{"IS:SCHEIA", 0},
{"IS:SINESTI", 0},
{"IS:SIPOTE", 0},
{"IS:SIRETEL", 0},
{"IS:STRUNGA", 0},
{"IS:TANSA", 0},
{"IS:TIBANA", 0},
{"IS:TIBANESTI", 0},
{"IS:TIGANASI", 0},
{"IS:TODIRESTI", 0},
{"IS:TOMESTI", 0},
{"IS:TUTORA", 0},
{"IS:UNGHENI", 0},
{"IS:VALEA LUPULUI", 0},
{"IS:VICTORIA", 0},
{"IS:VLADENI", 0},
{"IS:LUNGANI", 31.82},
{"IS:DOLHESTI", 21.19},
{"IS:MOTCA", 11.44},
{"IS:CIOHORANI", 10.33},
{"IS:GRAJDURI", 8.73},
{"IS:MIRONEASA", 8.05},
{"IS:STOLNICENI-PRAJESCU", 7.26},
{"IS:CIUREA", 6.13},
{"IS:VOINESTI", 6.1},
{"IS:DAGATA", 5.76},
{"IS:MIROSLOVESTI", 5.74},
{"IS:RADUCANENI", 4.6},
{"IS:VALEA SEACA", 2.23},
{"IS:HOLBOCA", 2.13},
{"IS:COMARNA", 1.18},
{"IS:VANATORI", 0.95},
{"IS:MADARJAC", 0.82},
{"IS:COTNARI", 0.81},
{"IS:BALS", 0.8},
{"IS:BUTEA", 0.74},
{"IS:CUCUTENI", 0.72},
{"IS:TRIFESTI", 0.64},
{"IS:SCHITU DUCA", 0.6},
{"IS:BELCESTI", 0.56},
{"IS:REDIU", 0.39},
{"IS:TATARUSI", 0.39},
{"IS:CRISTESTI", 0.35},
{"IS:COZMESTI", 0.23},
{"IS:PRISACANI", 0.18},
{"IS:MOVILENI", 0.18},
{"IS:FOCURI", 0.18},
{"IS:MIRCESTI", 0.16},
{"IS:ANDRIESENI", 0.12},
{"IS:COSTULENI", 0.12},
{"IS:MIROSLAVA", 0.11},
{"IS:PLUGARI", 0.08},
{"IS:BALTATI", 0.08},
{"IS:ERBICENI", 0.05},
{"IS:SCOBINTI", 0.04},




{"MM:BAIA MARE", 2.51},
{"MM:SIGHETU MARMATIEI", 1.3},
{"MM:BAIA SPRIE", 3.92},
{"MM:BORSA", 0.51},
{"MM:CAVNIC", 0.52},
{"MM:DRAGOMIRESTI", 0.37},
{"MM:SALISTEA DE SUS", 0},
{"MM:SEINI", 2.14},
{"MM:SOMCUTA MARE", 13.97},
{"MM:TARGU LAPUS", 0.86},
{"MM:TAUTII-MAGHERAUS", 0.95},
{"MM:ULMENI", 21.61},
{"MM:VISEU DE SUS", 0.35},
{"MM:ARDUSAT", 0},
{"MM:ARINIS", 0.28},
{"MM:ASUAJU DE SUS", 0.49},
{"MM:BAITA DE SUB CODRU", 1.23},
{"MM:BAIUT", 0},
{"MM:BARSANA", 0},
{"MM:BASESTI", 4.34},
{"MM:BICAZ", 0},
{"MM:BISTRA", 0.17},
{"MM:BOCICOIU MARE", 0},
{"MM:BOGDAN VODA", 0},
{"MM:BOIU MARE", 0},
{"MM:BOTIZA", 0},
{"MM:BUDESTI", 0},
{"MM:CALINESTI", 0},
{"MM:CAMPULUNG LA TISA", 3.62},
{"MM:CERNESTI", 3.07},
{"MM:CICARLAU", 0},
{"MM:COAS", 0},
{"MM:COLTAU", 36.64},
{"MM:COPALNIC-MANASTUR", 7.47},
{"MM:COROIENI", 19.06},
{"MM:CUPSENI", 0},
{"MM:DESESTI", 0},
{"MM:DUMBRAVITA", 0.25},
{"MM:FARCASA", 1.54},
{"MM:GARDANI", 0},
{"MM:GIULESTI", 0},
{"MM:GROSI", 0},
{"MM:GROSII TIBLESULUI", 1.62},
{"MM:IEUD", 0},
{"MM:LAPUS", 0},
{"MM:LEORDINA", 0},
{"MM:MIRESU MARE", 1.38},
{"MM:MOISEI", 0.03},
{"MM:OARTA DE JOS", 0},
{"MM:OCNA SUGATAG", 2.1},
{"MM:ONCESTI", 0},
{"MM:PETROVA", 0.59},
{"MM:POIENILE DE SUB MUNTE", 0},
{"MM:POIENILE IZEI", 0},
{"MM:RECEA", 1.07},
{"MM:REMETEA CHIOARULUI", 8.33},
{"MM:REMETI", 1.22},
{"MM:REPEDEA", 0.34},
{"MM:RONA DE JOS", 0},
{"MM:RONA DE SUS", 0},
{"MM:ROZAVLEA", 0.52},
{"MM:RUSCOVA", 3.28},
{"MM:SACALASENI", 3.35},
{"MM:SACEL", 0.09},
{"MM:SALSIG", 10.24},
{"MM:SAPANTA", 0},
{"MM:SARASAU", 2.19},
{"MM:SATULUNG", 19.86},
{"MM:SIEU", 0},
{"MM:SISESTI", 0},
{"MM:STRAMTURA", 0},
{"MM:SUCIU DE SUS", 4.52},
{"MM:VADU IZEI", 0},
{"MM:VALEA CHIOARULUI", 8.59},
{"MM:VIMA MICA", 0},
{"MM:VISEU DE JOS", 1.07},




{"MS:TARNAVENI", 10.65},
{"MS:SARMASU", 10.01},
{"MS:IERNUT", 9.72},
{"MS:LUDUS", 6.29},
{"MS:REGHIN", 6.22},
{"MS:MIERCUREA NIRAJULUI", 6.09},
{"MS:SIGHISOARA", 5.23},
{"MS:SANGEORGIU DE PADURE", 4.61},
{"MS:TARGU MURES", 2.32},
{"MS:SOVATA", 1.89},
{"MS:UNGHENI", 14.07},
{"MS:COZMA", 0},
{"MS:CRAIESTI", 0},
{"MS:IBANESTI", 0},
{"MS:STANCENI", 0},
{"MS:PETELEA", 47.03},
{"MS:ZAGAR", 38.84},
{"MS:FARAGAU", 38.09},
{"MS:BAHNEA", 34.5},
{"MS:VIISOARA", 31.95},
{"MS:BAGACIU", 31.16},
{"MS:SANPAUL", 30.9},
{"MS:VANATORI", 29.94},
{"MS:BEICA DE JOS", 29.93},
{"MS:OGRA", 29.2},
{"MS:MICA", 26.37},
{"MS:BAND", 25.67},
{"MS:CRACIUNESTI", 24.3},
{"MS:APOLD", 21.89},
{"MS:NADES", 18.4},
{"MS:ALUNIS", 18.2},
{"MS:DANES", 16.74},
{"MS:ERNEI", 16.33},
{"MS:SAULIA", 16.3},
{"MS:LIVEZENI", 15.62},
{"MS:COROISANMARTIN", 15.34},
{"MS:POGACEAUA", 15.12},
{"MS:ADAMUS", 14.96},
{"MS:SARATENI", 14.74},
{"MS:VARGATA", 14.34},
{"MS:TAURENI", 14.16},
{"MS:BALAUSERI", 13.54},
{"MS:SANGER", 13.42},
{"MS:ALBESTI", 13.17},
{"MS:SANPETRU DE CAMPIE", 12.84},
{"MS:GREBENISU DE CAMPIE", 12.53},
{"MS:SUSENI", 12.29},
{"MS:MIHESU DE CAMPIE", 11.77},
{"MS:SUPLAC", 11.69},
{"MS:GLODENI", 11.47},
{"MS:PASARENI", 11.15},
{"MS:VETCA", 10.99},
{"MS:SOLOVASTRU", 10.6},
{"MS:BREAZA", 10.55},
{"MS:MADARAS", 10.55},
{"MS:CEUASU DE CAMPIE", 10.33},
{"MS:CRISTESTI", 10.29},
{"MS:ACATARI", 10.19},
{"MS:SINCAI", 10.17},
{"MS:CUCI", 10.15},
{"MS:ZAU DE CAMPIE", 10.11},
{"MS:BATOS", 9.98},
{"MS:GANESTI", 9.63},
{"MS:BOGATA", 9.56},
{"MS:BICHIS", 9.32},
{"MS:GORNESTI", 9.31},
{"MS:VOIVODENI", 9.05},
{"MS:HODOSA", 9.04},
{"MS:SASCHIZ", 8.96},
{"MS:IDECIU DE JOS", 8.82},
{"MS:PANET", 8.8},
{"MS:DEDA", 8.49},
{"MS:SANGEORGIU DE MURES", 7.94},
{"MS:GURGHIU", 7.83},
{"MS:RICIU", 7.55},
{"MS:NEAUA", 7.52},
{"MS:BRANCOVENESTI", 7.5},
{"MS:CHIHERU DE JOS", 7.42},
{"MS:RUSII-MUNTI", 7.37},
{"MS:GHINDARI", 7.08},
{"MS:BALA", 7.01},
{"MS:VATAVA", 6.79},
{"MS:SANTANA DE MURES", 6.76},
{"MS:ATINTIS", 6.73},
{"MS:MAGHERANI", 5.81},
{"MS:LUNCA BRADULUI", 5.31},
{"MS:GHEORGHE DOJA", 5},
{"MS:SANCRAIU DE MURES", 4.17},
{"MS:EREMITU", 4.03},
{"MS:FANTANELE", 3.92},
{"MS:CHETANI", 3.68},
{"MS:CORUNCA", 3.12},
{"MS:VALEA LARGA", 2.42},
{"MS:LUNCA", 1.9},
{"MS:ICLANZEL", 1.83},
{"MS:CHIBED", 1.82},
{"MS:GALESTI", 1.47},
{"MS:BERENI", 1.33},
{"MS:CUCERDEA", 0.66},
{"MS:RASTOLITA", 0.48},
{"MS:PAPIU ILARIAN", 0.42},
{"MS:HODAC", 0.22},




{"PH:COMARNIC", 0},
{"PH:MIZIL", 15.16},
{"PH:BOLDESTI-SCAENI", 5.08},
{"PH:PLOIESTI", 2.4},
{"PH:CAMPINA", 1.94},
{"PH:URLATI", 1.29},
{"PH:SINAIA", 1.24},
{"PH:PLOPENI", 1.04},
{"PH:VALENII DE MUNTE", 0.91},
{"PH:AZUGA", 0.9},
{"PH:BUSTENI", 0.81},
{"PH:BAICOI", 0.21},
{"PH:SLANIC", 0.2},
{"PH:BREAZA", 0.04},
{"PH:ADUNATI", 0},
{"PH:ARICESTII ZELETIN", 0},
{"PH:BABA ANA", 0},
{"PH:BALTA DOAMNEI", 0},
{"PH:BATRANI", 0},
{"PH:BERTEA", 0},
{"PH:BREBU", 0},
{"PH:CALUGARENI", 0},
{"PH:CARBUNESTI", 0},
{"PH:CEPTURA", 0},
{"PH:CERASU", 0},
{"PH:CHIOJDEANCA", 0},
{"PH:CORNU", 0},
{"PH:COSMINELE", 0},
{"PH:DRAJNA", 0},
{"PH:GHERGHITA", 0},
{"PH:GORNET", 0},
{"PH:GORNET-CRICOV", 0},
{"PH:GURA VADULUI", 0},
{"PH:GURA VITIOAREI", 0},
{"PH:LAPOS", 0},
{"PH:MAGURENI", 0},
{"PH:OLARI", 0},
{"PH:PACURETI", 0},
{"PH:PLOPU", 0},
{"PH:PREDEAL-SARARI", 0},
{"PH:PROVITA DE SUS", 0},
{"PH:PUCHENII MARI", 0},
{"PH:SALCIA", 0},
{"PH:SALCIILE", 0},
{"PH:SCORTENI", 0},
{"PH:SECARIA", 0},
{"PH:SOIMARI", 0},
{"PH:SURANI", 0},
{"PH:TALEA", 0},
{"PH:TATARU", 0},
{"PH:TEISANI", 0},
{"PH:VADU SAPAT", 0},
{"PH:DUMBRAVA", 16.56},
{"PH:SANGERU", 16.52},
{"PH:SOTRILE", 16.02},
{"PH:FILIPESTII DE TARG", 15.96},
{"PH:VARBILAU", 11.17},
{"PH:BALTESTI", 11.01},
{"PH:PROVITA DE JOS", 10.03},
{"PH:DUMBRAVESTI", 8.59},
{"PH:PODENII NOI", 6.71},
{"PH:VALCANESTI", 6.25},
{"PH:BUCOV", 5.1},
{"PH:FILIPESTII DE PADURE", 4.31},
{"PH:DRAGANESTI", 3.93},
{"PH:FULGA", 3.62},
{"PH:BARCANESTI", 3.2},
{"PH:ARICESTII RAHTIVANI", 2.78},
{"PH:FLORESTI", 2.66},
{"PH:ALUNIS", 2.65},
{"PH:COCORASTII COLT", 2.47},
{"PH:APOSTOLACHE", 2.36},
{"PH:BLEJOI", 1.7},
{"PH:IZVOARELE", 1.6},
{"PH:POSESTI", 1.38},
{"PH:SIRNA", 1.28},
{"PH:RAFOV", 1.23},
{"PH:LIPANESTI", 1.21},
{"PH:STARCHIOJD", 0.98},
{"PH:MAGURELE", 0.53},
{"PH:JUGURENI", 0.49},
{"PH:CIORANI", 0.42},
{"PH:PAULESTI", 0.41},
{"PH:POIENARII BURCHII", 0.39},
{"PH:POIANA CAMPINA", 0.34},
{"PH:MANESTI", 0.33},
{"PH:COLCEAG", 0.31},
{"PH:VALEA CALUGAREASCA", 0.31},
{"PH:GORGOTA", 0.31},
{"PH:FANTANELE", 0.31},
{"PH:TOMSANI", 0.29},
{"PH:TINOSU", 0.29},
{"PH:BOLDESTI-GRADISTEA", 0.28},
{"PH:MANECIU", 0.24},
{"PH:TELEGA", 0.24},
{"PH:STEFESTI", 0.19},
{"PH:ALBESTI-PALEOLOGU", 0.18},
{"PH:VALEA DOFTANEI", 0.16},
{"PH:IORDACHEANU", 0.16},
{"PH:BANESTI", 0.15},
{"PH:COCORASTII MISLII", 0.12},
{"PH:BRAZI", 0.11},
{"PH:BERCENI", 0.1},
{"PH:TARGSORU VECHI", 0.08},




{"SV:BROSTENI", 0},
{"SV:FRASIN", 0},
{"SV:SIRET", 0},
{"SV:DOLHASCA", 12.22},
{"SV:VICOVU DE SUS", 5.05},
{"SV:SALCEA", 4.61},
{"SV:GURA HUMORULUI", 1.6},
{"SV:SOLCA", 1.42},
{"SV:RADAUTI", 0.84},
{"SV:FALTICENI", 0.73},
{"SV:CAJVANA", 0.72},
{"SV:VATRA DORNEI", 0.66},
{"SV:SUCEAVA", 0.64},
{"SV:LITENI", 0.23},
{"SV:CAMPULUNG MOLDOVENESC", 0.23},
{"SV:MILISAUTI", 0.14},
{"SV:BALCAUTI", 0},
{"SV:BOGDANESTI", 0},
{"SV:BOROAIA", 0},
{"SV:BOTOSANA", 0},
{"SV:BREAZA", 0},
{"SV:BUNESTI", 0},
{"SV:CACICA", 0},
{"SV:CALAFINDESTI", 0},
{"SV:CARLIBABA", 0},
{"SV:CIOCANESTI", 0},
{"SV:COSNA", 0},
{"SV:CRUCEA", 0},
{"SV:DARMANESTI", 0},
{"SV:DORNA-ARINI", 0},
{"SV:FANTANA MARE", 0},
{"SV:FRATAUTII NOI", 0},
{"SV:FRATAUTII VECHI", 0},
{"SV:FRUMOSU", 0},
{"SV:FUNDU MOLDOVEI", 0},
{"SV:GALANESTI", 0},
{"SV:GRAMESTI", 0},
{"SV:GRANICESTI", 0},
{"SV:HANTESTI", 0},
{"SV:HARTOP", 0},
{"SV:HORODNIC DE JOS", 0},
{"SV:HORODNICENI", 0},
{"SV:IACOBENI", 0},
{"SV:IASLOVAT", 0},
{"SV:IPOTESTI", 0},
{"SV:IZVOARELE SUCEVEI", 0},
{"SV:MANASTIREA HUMORULUI", 0},
{"SV:MOARA", 0},
{"SV:MOLDOVITA", 0},
{"SV:OSTRA", 0},
{"SV:PANACI", 0},
{"SV:POIANA STAMPEI", 0},
{"SV:POIENI-SOLCA", 0},
{"SV:PREUTESTI", 0},
{"SV:PUTNA", 0},
{"SV:RADASENI", 0},
{"SV:SARU DORNEI", 0},
{"SV:SATU MARE", 0},
{"SV:SERBAUTI", 0},
{"SV:SLATINA", 0},
{"SV:STRAJA", 0},
{"SV:TODIRESTI", 0},
{"SV:ULMA", 0},
{"SV:VATRA MOLDOVITEI", 0},
{"SV:VULTURESTI", 0},
{"SV:ZAMOSTEA", 0},
{"SV:ZVORISTEA", 0},
{"SV:VALEA MOLDOVEI", 39.08},
{"SV:PATRAUTI", 21.09},
{"SV:COMANESTI", 16.38},
{"SV:VOITINEL", 11.78},
{"SV:VERESTI", 10.48},
{"SV:CIPRIAN PORUMBESCU", 10.43},
{"SV:MITOCU DRAGOMIRNEI", 9.42},
{"SV:SUCEVITA", 9.27},
{"SV:BURLA", 7.91},
{"SV:PALTINOASA", 6.6},
{"SV:HORODNIC DE SUS", 6.54},
{"SV:DORNESTI", 6.14},
{"SV:CAPU CAMPULUI", 5.6},
{"SV:BERCHISESTI", 4.63},
{"SV:DOLHESTI", 4.17},
{"SV:UDESTI", 4.1},
{"SV:PARTESTII DE JOS", 3.96},
{"SV:SCHEIA", 3.63},
{"SV:CORNU LUNCII", 3.49},
{"SV:BOSANCI", 3.01},
{"SV:FORASTI", 2.29},
{"SV:VICOVU DE JOS", 1.84},
{"SV:VAMA", 1.55},
{"SV:BILCA", 1.48},
{"SV:MOLDOVA-SULITA", 1.18},
{"SV:ADANCATA", 1.09},
{"SV:STROIESTI", 1.06},
{"SV:VOLOVAT", 1.05},
{"SV:STULPICANI", 0.97},
{"SV:DORNA CANDRENILOR", 0.85},
{"SV:POJORATA", 0.83},
{"SV:SADOVA", 0.79},
{"SV:ARBORE", 0.7},
{"SV:DRAGUSENI", 0.66},
{"SV:MALINI", 0.63},
{"SV:ILISESTI", 0.58},
{"SV:BAIA", 0.39},
{"SV:DRAGOIESTI", 0.38},
{"SV:DUMBRAVENI", 0.37},
{"SV:FANTANELE", 0.33},
{"SV:SIMINICEA", 0.3},
{"SV:BRODINA", 0.27},
{"SV:VADU MOLDOVEI", 0.23},
{"SV:MUSENITA", 0.21},
{"SV:BALACEANA", 0.2},
{"SV:RASCA", 0.14},
{"SV:MARGINEA", 0.13},




{"B:BUCURESTI SECTORUL 1", 1.47},
{"B:BUCURESTI SECTORUL 2", 1.63},
{"B:BUCURESTI SECTORUL 3", 1.05},
{"B:BUCURESTI SECTORUL 4", 0.77},
{"B:BUCURESTI SECTORUL 5", 2.57},
{"B:BUCURESTI SECTORUL 6", 0.48},







 };
        public IUnitateRepository IUnitateRepository { get; set; }
        public IClasaRepository IClasaRepository { get; set; }
        public IScoalaRepository IScoalaRepository { get; set; }
        public IUnitateIntrebareRepository IUnitateIntrebareRepository { get; set; }
        public IMonitorIntrebareRepository IMonitorIntrebareRepository { get; set; }
        public IMonitorRepository IMonitorRepository { get; set; }
        public UnitateController(IUnitateRepository unitateRepository, IClasaRepository clasaRepository, IScoalaRepository scoalaRepository, IUnitateIntrebareRepository unitateIntrebareRepository, IMonitorIntrebareRepository monitorIntrebareRepository, IMonitorRepository monitorRepository)
        {
            IUnitateRepository = unitateRepository;
            IClasaRepository = clasaRepository;
            IScoalaRepository = scoalaRepository;
            IUnitateIntrebareRepository = unitateIntrebareRepository;
            IMonitorIntrebareRepository = monitorIntrebareRepository;
            IMonitorRepository = monitorRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Unitate>> Get()
        {
            return IUnitateRepository.GetAll();
        }

        [HttpGet("maff")]
        public List<Maff> GetMaff()
        {
            IEnumerable<Scoala> AllScoli = IScoalaRepository.GetAll();
            List<Unitate> AllUnitati = IUnitateRepository.GetAll();
            //AllUnitati.Sort((x, y) => x.ScoalaId.CompareTo(y.ScoalaId));
            AllUnitati = AllUnitati.OrderBy(o => o.ScoalaId).ThenByDescending(o => o.Statut).ToList();
            IEnumerable<Clasa> AllClase = IClasaRepository.GetAll();
            IEnumerable<UnitateIntrebare> AllUnitateIntrebari = IUnitateIntrebareRepository.GetAll();

            List<Maff> MyResults = new List<Maff>();

            string tRaspuns38 = "", tRaspuns39 = "", tRaspuns40 = "", tRaspuns41 = "", tRaspuns46 = "", tRaspuns47 = "", tLocalitate = "";
            foreach (Unitate MyUnitate in AllUnitati)
            {
                if (AllScoli.Where(x => x.Id == MyUnitate.ScoalaId).FirstOrDefault().NrInregC == null)
                {
                    if (MyUnitate.Moderator != "2")
                    {
                        if (MyUnitate.Statut == "PJ")
                        {
                            UnitateIntrebare action38 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 38).FirstOrDefault();
                            UnitateIntrebare action39 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 39).FirstOrDefault();
                            UnitateIntrebare action40 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 40).FirstOrDefault();
                            UnitateIntrebare action41 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 41).FirstOrDefault();
                            UnitateIntrebare action46 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 46).FirstOrDefault();
                            UnitateIntrebare action47 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 47).FirstOrDefault();

                            if (action38 != null) tRaspuns38 = action38.Raspuns;
                            else tRaspuns38 = null;
                            if (action39 != null) tRaspuns39 = action39.Raspuns;
                            else tRaspuns39 = null;
                            if (action40 != null) tRaspuns40 = action40.Raspuns;
                            else tRaspuns40 = null;
                            if (action41 != null) tRaspuns41 = action41.Raspuns;
                            else tRaspuns41 = null;
                            if (action46 != null) tRaspuns46 = action46.Raspuns;
                            else tRaspuns46 = null;
                            if (action47 != null) tRaspuns47 = action47.Raspuns;
                            else tRaspuns47 = null;

                            tLocalitate = MyUnitate.Localitate;
                        }
                        Maff MyMaff = new Maff();
                        Scoala TempScoala = AllScoli.Where(x => x.Id == MyUnitate.ScoalaId).First();
                        MyMaff.NumeScoala = TempScoala.Nume;
                        MyMaff.JudetS = TempScoala.Judet;
                        MyMaff.NrDep = TempScoala.NrInreg;
                        MyMaff.NrDepC = TempScoala.NrInregC;
                        if (TempScoala.Romi != null) MyMaff.RomiScoala = Int32.Parse(TempScoala.Romi);
                        if (TempScoala.Parinti != null) MyMaff.ParintiScoala = Int32.Parse(TempScoala.Parinti);
                        if (TempScoala.Dizabilitati != null) MyMaff.DizabilitatiScoala = Int32.Parse(TempScoala.Dizabilitati);
                        MyMaff.NumeU = MyUnitate.Nume;
                        MyMaff.IdMaff = MyUnitate.Id-1597;
                        MyMaff.ScoalaId = MyUnitate.ScoalaId;
                        MyMaff.LocalitateU = MyUnitate.Localitate;
                        MyMaff.StatutU = MyUnitate.Statut;
                        MyMaff.Raspuns38 = tRaspuns38;
                        MyMaff.Raspuns39 = tRaspuns39;
                        MyMaff.Raspuns40 = tRaspuns40;
                        MyMaff.Raspuns41 = tRaspuns41;
                        MyMaff.Raspuns46 = tRaspuns46;
                        MyMaff.Raspuns47 = tRaspuns47;
                        MyMaff.LocalitateS = tLocalitate;
                        MyMaff.Alerta1 = "OK";
                        MyMaff.Alerta2 = "OK";
                        MyMaff.Alerta3 = "OK";
                        MyMaff.Alerta4 = "OK";
                        MyMaff.Alerta5 = "OK";
                        MyMaff.Alerta6 = "OK";
                        MyMaff.Alerta7 = "OK";
                        MyMaff.Alerta8 = "OK";
                        MyMaff.Alerta9 = "OK";
                        MyMaff.Alerta10 = "OK";
                        MyMaff.Alerta11 = "OK";
                        if (MyUnitate.Total != null) MyMaff.Total = Int32.Parse(MyUnitate.Total);
                        if (MyUnitate.Romi != null) MyMaff.Romi = Int32.Parse(MyUnitate.Romi);
                        if (MyUnitate.Dizabilitati != null) MyMaff.Dizabilitati = Int32.Parse(MyUnitate.Dizabilitati);
                        if (MyUnitate.Parinti != null) MyMaff.Parinti = Int32.Parse(MyUnitate.Parinti);
                        if (MyUnitate.Burse != null) MyMaff.Burse = Int32.Parse(MyUnitate.Burse);
                        if (MyUnitate.Repetenti != null) MyMaff.Repetenti = Int32.Parse(MyUnitate.Repetenti);
                        if (MyUnitate.Online != null) MyMaff.Online = Int32.Parse(MyUnitate.Online);
                        if (MyUnitate.Remediala != null) MyMaff.Remediala = Int32.Parse(MyUnitate.Remediala);
                        MyMaff.TotalC = 0;
                        MyMaff.RomiC = 0;
                        MyMaff.DizabilitatiC = 0;
                        MyMaff.ParintiC = 0;
                        MyMaff.BurseC = 0;
                        MyMaff.RepetentiC = 0;
                        MyMaff.OnlineC = 0;
                        MyMaff.RemedialaC = 0;
                        MyMaff.BadClasaId = new List<int>();
                        MyMaff.BadClasaNume = new List<string>();
                        MyMaff.ExistaClasa15 = false;


                        IEnumerable<Clasa> MyClase = AllClase.Where(x => x.UnitateId == MyUnitate.Id);
                        foreach (Clasa MyClasa in MyClase)
                        {
                            if (MyClasa.Moderator != "2")
                            {
                                bool Ok = true;
                                if (MyClasa.Total2b != null &&
                                    MyClasa.Romi2b != null &&
                                    MyClasa.Dizabilitati2b != null &&
                                    MyClasa.Parinti2b != null &&
                                    MyClasa.Burse2b != null &&
                                    MyClasa.Repetenti2b != null &&
                                    MyClasa.Online2b != null &&
                                    MyClasa.Remediala2b != null &&
                                    MyClasa.Total != null &&
                                    MyClasa.Romi != null &&
                                    MyClasa.Dizabilitati != null &&
                                    MyClasa.Parinti != null &&
                                    MyClasa.Burse != null &&
                                    MyClasa.Repetenti != null &&
                                    MyClasa.Online != null &&
                                    MyClasa.Remediala != null)
                                {
                                    if (Int32.Parse(MyClasa.Total2b) > Int32.Parse(MyClasa.Total) ||
                                        Int32.Parse(MyClasa.Romi2b) > Int32.Parse(MyClasa.Romi) ||
                                        Int32.Parse(MyClasa.Dizabilitati2b) > Int32.Parse(MyClasa.Dizabilitati) ||
                                        Int32.Parse(MyClasa.Parinti2b) > Int32.Parse(MyClasa.Parinti) ||
                                        Int32.Parse(MyClasa.Burse2b) > Int32.Parse(MyClasa.Burse) ||
                                        Int32.Parse(MyClasa.Repetenti2b) > Int32.Parse(MyClasa.Repetenti) ||
                                        Int32.Parse(MyClasa.Online2b) > Int32.Parse(MyClasa.Online) ||
                                        Int32.Parse(MyClasa.Remediala2b) > Int32.Parse(MyClasa.Remediala)) Ok = false;
                                }
                                else
                                {
                                    Ok = false;
                                }
                                if (MyClasa.Total != null &&
                                    MyClasa.Romi != null &&
                                    MyClasa.Dizabilitati != null &&
                                    MyClasa.Parinti != null &&
                                    MyClasa.Burse != null &&
                                    MyClasa.Repetenti != null &&
                                    MyClasa.Online != null &&
                                    MyClasa.Remediala != null)
                                {
                                    MyMaff.TotalC += Int32.Parse(MyClasa.Total);
                                    MyMaff.RomiC += Int32.Parse(MyClasa.Romi);
                                    MyMaff.DizabilitatiC += Int32.Parse(MyClasa.Dizabilitati);
                                    MyMaff.ParintiC += Int32.Parse(MyClasa.Parinti);
                                    MyMaff.BurseC += Int32.Parse(MyClasa.Burse);
                                    MyMaff.RepetentiC += Int32.Parse(MyClasa.Repetenti);
                                    MyMaff.OnlineC += Int32.Parse(MyClasa.Online);
                                    MyMaff.RemedialaC += Int32.Parse(MyClasa.Remediala);
                                    if (Int32.Parse(MyClasa.Romi) >= 15) MyMaff.ExistaClasa15 = true;
                                }

                                if (Ok == false)
                                {
                                    MyMaff.BadClasaId.Add(MyClasa.Id);
                                    MyMaff.BadClasaNume.Add(MyClasa.Cifra + MyClasa.Litera);
                                }
                            }
                        }

                        if (MyMaff.TotalC != 0)
                        {
                            MyMaff.RomiP = (double)MyMaff.Romi / (double)MyMaff.Total * (double)100;
                            MyMaff.RomiP *= 100;
                            MyMaff.RomiP = ((double)((int)MyMaff.RomiP)) / 100;
                        }
                        else MyMaff.RomiP = 0;

                        string tKey = MyMaff.JudetS.ToUpper().Replace('Ă', 'A').Replace('Â', 'A').Replace('Î', 'I').Replace('Ș', 'S').Replace('Ț', 'T').Trim() + ":" + MyMaff.LocalitateS.ToUpper().Replace('Ă', 'A').Replace('Â', 'A').Replace('Î', 'I').Replace('Ș', 'S').Replace('Ț', 'T').Trim();
                        if (ProcentRomi.ContainsKey(tKey)) MyMaff.RomiLocalitate = ProcentRomi[tKey];
                        else MyMaff.RomiLocalitate = 0;
                        if (MyMaff.RomiP < MyMaff.RomiLocalitate)
                        {
                            MyMaff.Alerta1 = "Alerta 1.";
                        }

                        if (string.Equals(MyMaff.Raspuns38, "DA"))
                            if (MyMaff.RomiScoala < 15 || !MyMaff.ExistaClasa15)
                                MyMaff.Alerta4 = "Alerta 4.";

                        if (string.Equals(MyMaff.Raspuns39, "DA"))
                            if (MyMaff.RomiP < 10)
                                MyMaff.Alerta5 = "Alerta 5.";

                        if (MyMaff.Total != MyMaff.TotalC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Romi != MyMaff.RomiC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Dizabilitati != MyMaff.DizabilitatiC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Parinti != MyMaff.ParintiC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Burse != MyMaff.BurseC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Repetenti != MyMaff.RepetentiC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Online != MyMaff.OnlineC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Remediala != MyMaff.RemedialaC) MyMaff.Alerta7 = "Alerta 7.";

                        if (MyMaff.BadClasaId.Count() > 0) MyMaff.Alerta8 = "Alerta 8.";

                        if (MyMaff.Raspuns41 != null && MyMaff.Raspuns41 != "")
                        {
                            List<string> tempSplit = MyMaff.Raspuns41.Split(new[] { '|' }, 2)[0].Split(',').ToList();
                            if (tempSplit[9] == "true" || tempSplit[10] == "true" || tempSplit[11] == "true")
                            {
                                if (MyMaff.RomiScoala != 0)
                                    MyMaff.Alerta9 = "Alerta 9.";
                            }
                            else
                            {
                                MyMaff.Alerta9 = "Alerta 9.";
                                if (string.Equals(MyMaff.Raspuns41.Split(new[] { '|' }, 2)[0], "false,false,false,false,false,false,false,false,true,false,false,false"))
                                    MyMaff.Alerta9 = "OK";
                            }

                        }

                        if (MyMaff.Raspuns46 != null && MyMaff.Raspuns46 != "")
                        {
                            List<string> tempSplit = MyMaff.Raspuns46.Split(new[] { '|' }, 2)[0].Split(',').ToList();
                            if (tempSplit[6] == "true" || tempSplit[7] == "true" || tempSplit[8] == "true")
                            {
                                if (MyMaff.ParintiScoala != 0)
                                    MyMaff.Alerta10 = "Alerta 10.";
                            }
                            else
                            {
                                MyMaff.Alerta10 = "Alerta 10.";
                                if (string.Equals(MyMaff.Raspuns46.Split(new[] { '|' }, 2)[0], "false,false,false,false,false,true,false,false,false"))
                                    MyMaff.Alerta10 = "OK";
                            }

                        }

                        if (MyMaff.Raspuns47 != null && MyMaff.Raspuns47 != "")
                        {
                            List<string> tempSplit = MyMaff.Raspuns47.Split(new[] { '|' }, 2)[0].Split(',').ToList();
                            if (tempSplit[6] == "true" || tempSplit[7] == "true" || tempSplit[8] == "true")
                            {
                                if (MyMaff.DizabilitatiScoala != 0)
                                    MyMaff.Alerta11 = "Alerta 11.";
                            }
                            else
                            {
                                MyMaff.Alerta11 = "Alerta 11.";
                                if (string.Equals(MyMaff.Raspuns47.Split(new[] { '|' }, 2)[0], "false,false,false,false,true,false,false,false,false"))
                                    MyMaff.Alerta11 = "OK";
                            }

                        }

                        switch (MyMaff.JudetS)
                        {
                            case "B":
                                MyMaff.JudetS = "Bucuresti";
                                break;
                            case "BT":
                                MyMaff.JudetS = "Botosani";
                                break;
                            case "BV":
                                MyMaff.JudetS = "Brasov";
                                break;
                            case "CJ":
                                MyMaff.JudetS = "Cluj";
                                break;
                            case "CT":
                                MyMaff.JudetS = "Constanta";
                                break;
                            case "IL":
                                MyMaff.JudetS = "Ialomita";
                                break;
                            case "IS":
                                MyMaff.JudetS = "Iasi";
                                break;
                            case "MM":
                                MyMaff.JudetS = "Maramures";
                                break;
                            case "MS":
                                MyMaff.JudetS = "Mures";
                                break;
                            case "PH":
                                MyMaff.JudetS = "Prahova";
                                break;
                            case "SV":
                                MyMaff.JudetS = "Suceava";
                                break;
                            default:
                                break;
                        }

                        MyResults.Add(MyMaff);
                    }
                }
                else
                {
                    if (MyUnitate.Moderator != "1")
                    {
                        if (MyUnitate.Statut == "PJ")
                        {
                            UnitateIntrebare action38 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 38).FirstOrDefault();
                            UnitateIntrebare action39 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 39).FirstOrDefault();
                            UnitateIntrebare action40 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 40).FirstOrDefault();
                            UnitateIntrebare action41 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 41).FirstOrDefault();
                            UnitateIntrebare action46 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 46).FirstOrDefault();
                            UnitateIntrebare action47 = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id && x.IntrebareId == 47).FirstOrDefault();

                            if (action38 != null) tRaspuns38 = action38.RaspunsC;
                            else tRaspuns38 = null;
                            if (action39 != null) tRaspuns39 = action39.RaspunsC;
                            else tRaspuns39 = null;
                            if (action40 != null) tRaspuns40 = action40.RaspunsC;
                            else tRaspuns40 = null;
                            if (action41 != null) tRaspuns41 = action41.RaspunsC;
                            else tRaspuns41 = null;
                            if (action46 != null) tRaspuns46 = action46.RaspunsC;
                            else tRaspuns46 = null;
                            if (action47 != null) tRaspuns47 = action47.RaspunsC;
                            else tRaspuns47 = null;

                            tLocalitate = MyUnitate.Localitate;
                        }
                        Maff MyMaff = new Maff();
                        Scoala TempScoala = AllScoli.Where(x => x.Id == MyUnitate.ScoalaId).First();
                        MyMaff.NumeScoala = TempScoala.Nume;
                        MyMaff.JudetS = TempScoala.Judet;
                        MyMaff.NrDep = TempScoala.NrInreg;
                        MyMaff.NrDepC = TempScoala.NrInregC;
                        if (TempScoala.RomiC != null) MyMaff.RomiScoala = Int32.Parse(TempScoala.RomiC);
                        if (TempScoala.ParintiC != null) MyMaff.ParintiScoala = Int32.Parse(TempScoala.ParintiC);
                        if (TempScoala.DizabilitatiC != null) MyMaff.DizabilitatiScoala = Int32.Parse(TempScoala.DizabilitatiC);
                        MyMaff.NumeU = MyUnitate.Nume;
                        MyMaff.IdMaff = MyUnitate.Id-1597;
                        MyMaff.ScoalaId = MyUnitate.ScoalaId;
                        MyMaff.LocalitateU = MyUnitate.Localitate;
                        MyMaff.StatutU = MyUnitate.Statut;
                        MyMaff.Raspuns38 = tRaspuns38;
                        MyMaff.Raspuns39 = tRaspuns39;
                        MyMaff.Raspuns40 = tRaspuns40;
                        MyMaff.Raspuns41 = tRaspuns41;
                        MyMaff.Raspuns46 = tRaspuns46;
                        MyMaff.Raspuns47 = tRaspuns47;
                        MyMaff.LocalitateS = tLocalitate;
                        MyMaff.Alerta1 = "OK";
                        MyMaff.Alerta2 = "OK";
                        MyMaff.Alerta3 = "OK";
                        MyMaff.Alerta4 = "OK";
                        MyMaff.Alerta5 = "OK";
                        MyMaff.Alerta6 = "OK";
                        MyMaff.Alerta7 = "OK";
                        MyMaff.Alerta8 = "OK";
                        MyMaff.Alerta9 = "OK";
                        MyMaff.Alerta10 = "OK";
                        MyMaff.Alerta11 = "OK";
                        if (MyUnitate.TotalC != null) MyMaff.Total = Int32.Parse(MyUnitate.TotalC);
                        if (MyUnitate.RomiC != null) MyMaff.Romi = Int32.Parse(MyUnitate.RomiC);
                        if (MyUnitate.DizabilitatiC != null) MyMaff.Dizabilitati = Int32.Parse(MyUnitate.DizabilitatiC);
                        if (MyUnitate.ParintiC != null) MyMaff.Parinti = Int32.Parse(MyUnitate.ParintiC);
                        if (MyUnitate.BurseC != null) MyMaff.Burse = Int32.Parse(MyUnitate.BurseC);
                        if (MyUnitate.RepetentiC != null) MyMaff.Repetenti = Int32.Parse(MyUnitate.RepetentiC);
                        if (MyUnitate.OnlineC != null) MyMaff.Online = Int32.Parse(MyUnitate.OnlineC);
                        if (MyUnitate.RemedialaC != null) MyMaff.Remediala = Int32.Parse(MyUnitate.RemedialaC);
                        MyMaff.TotalC = 0;
                        MyMaff.RomiC = 0;
                        MyMaff.DizabilitatiC = 0;
                        MyMaff.ParintiC = 0;
                        MyMaff.BurseC = 0;
                        MyMaff.RepetentiC = 0;
                        MyMaff.OnlineC = 0;
                        MyMaff.RemedialaC = 0;
                        MyMaff.BadClasaId = new List<int>();
                        MyMaff.BadClasaNume = new List<string>();
                        MyMaff.ExistaClasa15 = false;


                        IEnumerable<Clasa> MyClase = AllClase.Where(x => x.UnitateId == MyUnitate.Id);
                        foreach (Clasa MyClasa in MyClase)
                        {
                            if (MyClasa.Moderator != "1")
                            {
                                bool Ok = true;
                                if (MyClasa.Total2bC != null &&
                                    MyClasa.Romi2bC != null &&
                                    MyClasa.Dizabilitati2bC != null &&
                                    MyClasa.Parinti2bC != null &&
                                    MyClasa.Burse2bC != null &&
                                    MyClasa.Repetenti2bC != null &&
                                    MyClasa.Online2bC != null &&
                                    MyClasa.Remediala2bC != null &&
                                    MyClasa.TotalC != null &&
                                    MyClasa.RomiC != null &&
                                    MyClasa.DizabilitatiC != null &&
                                    MyClasa.ParintiC != null &&
                                    MyClasa.BurseC != null &&
                                    MyClasa.RepetentiC != null &&
                                    MyClasa.OnlineC != null &&
                                    MyClasa.RemedialaC != null)
                                {
                                    if (Int32.Parse(MyClasa.Total2bC) > Int32.Parse(MyClasa.TotalC) ||
                                        Int32.Parse(MyClasa.Romi2bC) > Int32.Parse(MyClasa.RomiC) ||
                                        Int32.Parse(MyClasa.Dizabilitati2bC) > Int32.Parse(MyClasa.DizabilitatiC) ||
                                        Int32.Parse(MyClasa.Parinti2bC) > Int32.Parse(MyClasa.ParintiC) ||
                                        Int32.Parse(MyClasa.Burse2bC) > Int32.Parse(MyClasa.BurseC) ||
                                        Int32.Parse(MyClasa.Repetenti2bC) > Int32.Parse(MyClasa.RepetentiC) ||
                                        Int32.Parse(MyClasa.Online2bC) > Int32.Parse(MyClasa.OnlineC) ||
                                        Int32.Parse(MyClasa.Remediala2bC) > Int32.Parse(MyClasa.RemedialaC)) Ok = false;
                                }
                                else
                                {
                                    Ok = false;
                                }
                                if (MyClasa.TotalC != null &&
                                    MyClasa.RomiC != null &&
                                    MyClasa.DizabilitatiC != null &&
                                    MyClasa.ParintiC != null &&
                                    MyClasa.BurseC != null &&
                                    MyClasa.RepetentiC != null &&
                                    MyClasa.OnlineC != null &&
                                    MyClasa.RemedialaC != null)
                                {
                                    MyMaff.TotalC += Int32.Parse(MyClasa.TotalC);
                                    MyMaff.RomiC += Int32.Parse(MyClasa.RomiC);
                                    MyMaff.DizabilitatiC += Int32.Parse(MyClasa.DizabilitatiC);
                                    MyMaff.ParintiC += Int32.Parse(MyClasa.ParintiC);
                                    MyMaff.BurseC += Int32.Parse(MyClasa.BurseC);
                                    MyMaff.RepetentiC += Int32.Parse(MyClasa.RepetentiC);
                                    MyMaff.OnlineC += Int32.Parse(MyClasa.OnlineC);
                                    MyMaff.RemedialaC += Int32.Parse(MyClasa.RemedialaC);
                                    if (Int32.Parse(MyClasa.RomiC) >= 15) MyMaff.ExistaClasa15 = true;
                                }

                                if (Ok == false)
                                {
                                    MyMaff.BadClasaId.Add(MyClasa.Id);
                                    MyMaff.BadClasaNume.Add(MyClasa.Cifra + MyClasa.LiteraC);
                                }
                            }
                        }

                        if (MyMaff.TotalC != 0)
                        {
                            MyMaff.RomiP = (double)MyMaff.Romi / (double)MyMaff.Total * (double)100;
                            MyMaff.RomiP *= 100;
                            MyMaff.RomiP = ((double)((int)MyMaff.RomiP)) / 100;
                        }
                        else MyMaff.RomiP = 0;

                        string tKey = MyMaff.JudetS.ToUpper().Replace('Ă', 'A').Replace('Â', 'A').Replace('Î', 'I').Replace('Ș', 'S').Replace('Ț', 'T').Trim() + ":" + MyMaff.LocalitateS.ToUpper().Replace('Ă', 'A').Replace('Â', 'A').Replace('Î', 'I').Replace('Ș', 'S').Replace('Ț', 'T').Trim();
                        if (ProcentRomi.ContainsKey(tKey)) MyMaff.RomiLocalitate = ProcentRomi[tKey];
                        else MyMaff.RomiLocalitate = 0;
                        if (MyMaff.RomiP < MyMaff.RomiLocalitate)
                        {
                            MyMaff.Alerta1 = "Alerta 1.";
                        }

                        if (string.Equals(MyMaff.Raspuns38, "DA"))
                            if (MyMaff.RomiScoala < 15 || !MyMaff.ExistaClasa15)
                                MyMaff.Alerta4 = "Alerta 4.";

                        if (string.Equals(MyMaff.Raspuns39, "DA"))
                            if (MyMaff.RomiP < 10)
                                MyMaff.Alerta5 = "Alerta 5.";

                        if (MyMaff.Total != MyMaff.TotalC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Romi != MyMaff.RomiC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Dizabilitati != MyMaff.DizabilitatiC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Parinti != MyMaff.ParintiC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Burse != MyMaff.BurseC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Repetenti != MyMaff.RepetentiC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Online != MyMaff.OnlineC) MyMaff.Alerta7 = "Alerta 7.";
                        if (MyMaff.Remediala != MyMaff.RemedialaC) MyMaff.Alerta7 = "Alerta 7.";

                        if (MyMaff.BadClasaId.Count() > 0) MyMaff.Alerta8 = "Alerta 8.";

                        if (MyMaff.Raspuns41 != null && MyMaff.Raspuns41 != "")
                        {
                            List<string> tempSplit = MyMaff.Raspuns41.Split(new[] { '|' }, 2)[0].Split(',').ToList();
                            if (tempSplit[9] == "true" || tempSplit[10] == "true" || tempSplit[11] == "true")
                            {
                                if (MyMaff.RomiScoala != 0)
                                    MyMaff.Alerta9 = "Alerta 9.";
                            }
                            else
                            {
                                MyMaff.Alerta9 = "Alerta 9.";
                                if (string.Equals(MyMaff.Raspuns41.Split(new[] { '|' }, 2)[0], "false,false,false,false,false,false,false,false,true,false,false,false"))
                                    MyMaff.Alerta9 = "OK";
                            }

                        }

                        if (MyMaff.Raspuns46 != null && MyMaff.Raspuns46 != "")
                        {
                            List<string> tempSplit = MyMaff.Raspuns46.Split(new[] { '|' }, 2)[0].Split(',').ToList();
                            if (tempSplit[6] == "true" || tempSplit[7] == "true" || tempSplit[8] == "true")
                            {
                                if (MyMaff.ParintiScoala != 0)
                                    MyMaff.Alerta10 = "Alerta 10.";
                            }
                            else
                            {
                                MyMaff.Alerta10 = "Alerta 10.";
                                if (string.Equals(MyMaff.Raspuns46.Split(new[] { '|' }, 2)[0], "false,false,false,false,false,true,false,false,false"))
                                    MyMaff.Alerta10 = "OK";
                            }

                        }

                        if (MyMaff.Raspuns47 != null && MyMaff.Raspuns47 != "")
                        {
                            List<string> tempSplit = MyMaff.Raspuns47.Split(new[] { '|' }, 2)[0].Split(',').ToList();
                            if (tempSplit[6] == "true" || tempSplit[7] == "true" || tempSplit[8] == "true")
                            {
                                if (MyMaff.DizabilitatiScoala != 0)
                                    MyMaff.Alerta11 = "Alerta 11.";
                            }
                            else
                            {
                                MyMaff.Alerta11 = "Alerta 11.";
                                if (string.Equals(MyMaff.Raspuns47.Split(new[] { '|' }, 2)[0], "false,false,false,false,true,false,false,false,false"))
                                    MyMaff.Alerta11 = "OK";
                            }

                        }

                        switch (MyMaff.JudetS)
                        {
                            case "B":
                                MyMaff.JudetS = "Bucuresti";
                                break;
                            case "BT":
                                MyMaff.JudetS = "Botosani";
                                break;
                            case "BV":
                                MyMaff.JudetS = "Brasov";
                                break;
                            case "CJ":
                                MyMaff.JudetS = "Cluj";
                                break;
                            case "CT":
                                MyMaff.JudetS = "Constanta";
                                break;
                            case "IL":
                                MyMaff.JudetS = "Ialomita";
                                break;
                            case "IS":
                                MyMaff.JudetS = "Iasi";
                                break;
                            case "MM":
                                MyMaff.JudetS = "Maramures";
                                break;
                            case "MS":
                                MyMaff.JudetS = "Mures";
                                break;
                            case "PH":
                                MyMaff.JudetS = "Prahova";
                                break;
                            case "SV":
                                MyMaff.JudetS = "Suceava";
                                break;
                            default:
                                break;
                        }

                        MyResults.Add(MyMaff);
                    }
                }
            }
            return MyResults;
        }

        [HttpGet("scoring")]
        public List<Scoring> GetScoring()
        {
            IEnumerable<Scoala> AllScoli = IScoalaRepository.GetAll();
            List<Unitate> AllUnitati = IUnitateRepository.GetAll().OrderBy(o => o.ScoalaId).ThenByDescending(o => o.Statut).ToList();
            IEnumerable<Clasa> AllClase = IClasaRepository.GetAll();
            IEnumerable<UnitateIntrebare> AllUnitateIntrebari = IUnitateIntrebareRepository.GetAll();

            List<Scoring> MyScores = new List<Scoring>();

            string tLocalitate = "";
            foreach (Unitate MyUnitate in AllUnitati)
            {
                if (MyUnitate.Moderator != "1")
                {
                    
                    Scoring MyScoring = new Scoring();
                    Scoala TempScoala = AllScoli.Where(x => x.Id == MyUnitate.ScoalaId).FirstOrDefault();
                    if (MyUnitate.Statut == "PJ")
                    {
                        tLocalitate = MyUnitate.Localitate;
                    }

                    MyScoring.NumeScoala = TempScoala.Nume;
                    MyScoring.JudetS = TempScoala.Judet;
                    MyScoring.LocalitateS = tLocalitate;

                    if (TempScoala.TotalC != null)
                    {
                        if (TempScoala.RomiC != null) MyScoring.ScorA1 = Math.Round(Double.Parse(TempScoala.RomiC) / Double.Parse(TempScoala.TotalC) * 100, 2, MidpointRounding.AwayFromZero);
                        if (TempScoala.DizabilitatiC != null) MyScoring.ScorB1 = Math.Round(Double.Parse(TempScoala.DizabilitatiC) / Double.Parse(TempScoala.TotalC) * 100, 2, MidpointRounding.AwayFromZero);
                        if (TempScoala.ParintiC != null) MyScoring.ScorC1 = Math.Round(Double.Parse(TempScoala.ParintiC) / Double.Parse(TempScoala.TotalC) * 100, 2, MidpointRounding.AwayFromZero);
                        if (TempScoala.BurseC != null) MyScoring.ScorC6 = Math.Round(Double.Parse(TempScoala.BurseC) / Double.Parse(TempScoala.TotalC) * 100, 2, MidpointRounding.AwayFromZero);
                    }

                    MyScoring.NumeU = MyUnitate.Nume;
                    MyScoring.IdScoring = MyUnitate.Id-1597;
                    MyScoring.StatutU = MyUnitate.Statut;

                    if (MyUnitate.TotalC != null)
                    {
                        if (MyUnitate.RomiC != null) MyScoring.RomiUnitateP = Math.Round(Double.Parse(MyUnitate.RomiC) / Double.Parse(MyUnitate.TotalC) * 100, 2, MidpointRounding.AwayFromZero);
                        if (MyUnitate.DizabilitatiC != null) MyScoring.DizabilitatiUnitateP = Math.Round(Double.Parse(MyUnitate.DizabilitatiC) / Double.Parse(MyUnitate.TotalC) * 100, 2, MidpointRounding.AwayFromZero);
                        if (MyUnitate.ParintiC != null) MyScoring.ParintiUnitateP = Math.Round(Double.Parse(MyUnitate.ParintiC) / Double.Parse(MyUnitate.TotalC) * 100, 2, MidpointRounding.AwayFromZero);
                        if (MyUnitate.BurseC != null) MyScoring.BurseUnitateP = Math.Round(Double.Parse(MyUnitate.BurseC) / Double.Parse(MyUnitate.TotalC) * 100, 2, MidpointRounding.AwayFromZero);
                    }

                    if (TempScoala.TotalC != null && MyUnitate.TotalC != null)
                    {
                        MyScoring.ScorA2 = Math.Round(Math.Abs(MyScoring.RomiUnitateP - MyScoring.ScorA1) / 10, 2, MidpointRounding.AwayFromZero);
                        MyScoring.ScorB2 = Math.Round(Math.Abs(MyScoring.DizabilitatiUnitateP - MyScoring.ScorB1) / 10, 2, MidpointRounding.AwayFromZero);
                        MyScoring.ScorC2 = Math.Round(Math.Abs(MyScoring.ParintiUnitateP - MyScoring.ScorC1) / 10, 2, MidpointRounding.AwayFromZero);
                        MyScoring.ScorC7 = Math.Round(Math.Abs(MyScoring.BurseUnitateP - MyScoring.ScorC6) / 10, 2, MidpointRounding.AwayFromZero);
                    }

                    MyScoring.NrDep = TempScoala.NrInreg;
                    MyScoring.NrDepC = TempScoala.NrInregC;
                    MyScoring.ScoalaId = MyUnitate.ScoalaId;


                    

                    MyScoring.TotalNivel = new List<double>(new double[9]);
                    MyScoring.RomiNivel = new List<double>(new double[9]);
                    MyScoring.DizabilitatiNivel = new List<double>(new double[9]);
                    MyScoring.ParintiNivel = new List<double>(new double[9]);
                    MyScoring.BurseNivel = new List<double>(new double[9]);
                    MyScoring.RepetentiNivel = new List<double>(new double[9]);
                    MyScoring.OnlineNivel = new List<double>(new double[9]);
                    MyScoring.RemedialaNivel = new List<double>(new double[9]);

                    


                    List<Clasa> MyClase = AllClase.Where(x => x.UnitateId == MyUnitate.Id).Where(o=> o.CladireC != null).OrderBy(o => o.CladireC).ToList();


                    if (MyClase.Count() > 0)
                    {
                        MyUnitate.NrCladiriC = Int32.Parse(MyClase.Max(o => o.CladireC));
                        MyScoring.tempWOW = MyUnitate.NrCladiriC;
                    }
                    else
                    {
                        MyUnitate.NrCladiriC = 0;
                    }

                    MyScoring.TotalCladire = new List<double>(new double[MyUnitate.NrCladiriC]);
                    MyScoring.RomiCladire = new List<double>(new double[MyUnitate.NrCladiriC]);
                    MyScoring.DizabilitatiCladire = new List<double>(new double[MyUnitate.NrCladiriC]);
                    MyScoring.ParintiCladire = new List<double>(new double[MyUnitate.NrCladiriC]);
                    MyScoring.BurseCladire = new List<double>(new double[MyUnitate.NrCladiriC]);

                    foreach (Clasa MyClasa in MyClase)
                    {
                        if (MyClasa.Moderator != "1")
                        {

                            if (MyClasa.Total2bC != null &&
                                MyClasa.Romi2bC != null &&
                                MyClasa.Dizabilitati2bC != null &&
                                MyClasa.Parinti2bC != null &&
                                MyClasa.Burse2bC != null &&
                                MyClasa.Repetenti2bC != null &&
                                MyClasa.Online2bC != null &&
                                MyClasa.Remediala2bC != null &&
                                MyClasa.TotalC != null &&
                                MyClasa.RomiC != null &&
                                MyClasa.DizabilitatiC != null &&
                                MyClasa.ParintiC != null &&
                                MyClasa.BurseC != null &&
                                MyClasa.RepetentiC != null &&
                                MyClasa.OnlineC != null &&
                                MyClasa.RemedialaC != null &&
                                MyClasa.CladireC != null)
                            {
                                MyScoring.TotalCladire[Int32.Parse(MyClasa.CladireC) - 1] += Double.Parse(MyClasa.TotalC);
                                MyScoring.RomiCladire[Int32.Parse(MyClasa.CladireC) - 1] += Double.Parse(MyClasa.RomiC);
                                MyScoring.DizabilitatiCladire[Int32.Parse(MyClasa.CladireC) - 1] += Double.Parse(MyClasa.DizabilitatiC);
                                MyScoring.ParintiCladire[Int32.Parse(MyClasa.CladireC) - 1] += Double.Parse(MyClasa.ParintiC);
                                MyScoring.BurseCladire[Int32.Parse(MyClasa.CladireC) - 1] += Double.Parse(MyClasa.BurseC);

                                if (MyClasa.Cifra != "Mixt")
                                {
                                    MyScoring.TotalNivel[Int32.Parse(MyClasa.Cifra)] += Double.Parse(MyClasa.TotalC);
                                    MyScoring.RomiNivel[Int32.Parse(MyClasa.Cifra)] += Double.Parse(MyClasa.RomiC);
                                    MyScoring.DizabilitatiNivel[Int32.Parse(MyClasa.Cifra)] += Double.Parse(MyClasa.DizabilitatiC);
                                    MyScoring.ParintiNivel[Int32.Parse(MyClasa.Cifra)] += Double.Parse(MyClasa.ParintiC);
                                    MyScoring.BurseNivel[Int32.Parse(MyClasa.Cifra)] += Double.Parse(MyClasa.BurseC);
                                    MyScoring.RepetentiNivel[Int32.Parse(MyClasa.Cifra)] += Double.Parse(MyClasa.RepetentiC);
                                    MyScoring.OnlineNivel[Int32.Parse(MyClasa.Cifra)] += Double.Parse(MyClasa.OnlineC);
                                    MyScoring.RemedialaNivel[Int32.Parse(MyClasa.Cifra)] += Double.Parse(MyClasa.RemedialaC);
                                }
                            }


                        }
                    }

                    MyScoring.RomiScorCladire = new List<double>(new double[MyUnitate.NrCladiriC]);
                    MyScoring.DizabilitatiScorCladire = new List<double>(new double[MyUnitate.NrCladiriC]);
                    MyScoring.ParintiScorCladire = new List<double>(new double[MyUnitate.NrCladiriC]);
                    MyScoring.BurseScorCladire = new List<double>(new double[MyUnitate.NrCladiriC]);

                    for (int i = 0; i < MyUnitate.NrCladiriC; i++)
                    {
                        MyScoring.RomiScorCladire[i] = Math.Round(Math.Abs((MyScoring.RomiCladire[i] / MyScoring.TotalCladire[i] * 100) - MyScoring.RomiUnitateP) / 10, 2, MidpointRounding.AwayFromZero);
                        MyScoring.DizabilitatiScorCladire[i] = Math.Round(Math.Abs((MyScoring.DizabilitatiCladire[i] / MyScoring.TotalCladire[i] * 100) - MyScoring.DizabilitatiUnitateP) / 10, 2, MidpointRounding.AwayFromZero);
                        MyScoring.ParintiScorCladire[i] = Math.Round(Math.Abs((MyScoring.ParintiCladire[i] / MyScoring.TotalCladire[i] * 100) - MyScoring.ParintiUnitateP) / 10, 2, MidpointRounding.AwayFromZero);
                        MyScoring.BurseScorCladire[i] = Math.Round(Math.Abs((MyScoring.BurseCladire[i] / MyScoring.TotalCladire[i] * 100) - MyScoring.BurseUnitateP) / 10, 2, MidpointRounding.AwayFromZero);
                    }

                    if (MyScoring.RomiScorCladire.Count() > 0)
                    {
                        MyScoring.ScorA3 = MyScoring.RomiScorCladire.Max();
                        MyScoring.RomiScorCladireIndex = MyScoring.RomiScorCladire.IndexOf(MyScoring.ScorA3) + 1;
                    }
                    else MyScoring.ScorA3 = 0;

                    if (MyScoring.DizabilitatiScorCladire.Count() > 0)
                    {
                        MyScoring.ScorB3 = MyScoring.DizabilitatiScorCladire.Max();
                        MyScoring.DizabilitatiScorCladireIndex = MyScoring.DizabilitatiScorCladire.IndexOf(MyScoring.ScorB3) + 1;
                    }
                    else MyScoring.ScorB3 = 0;

                    if (MyScoring.ParintiScorCladire.Count() > 0)
                    {
                        MyScoring.ScorC3 = MyScoring.ParintiScorCladire.Max();
                        MyScoring.ParintiScorCladireIndex = MyScoring.ParintiScorCladire.IndexOf(MyScoring.ScorC3) + 1;
                    }
                    else MyScoring.ScorC3 = 0;

                    if (MyScoring.BurseScorCladire.Count() > 0)
                    {
                        MyScoring.ScorC8 = MyScoring.BurseScorCladire.Max();
                        MyScoring.BurseScorCladireIndex = MyScoring.BurseScorCladire.IndexOf(MyScoring.ScorC8) + 1;
                    }
                    else MyScoring.ScorC8 = 0;

                    MyScoring.RomiScorNivel = new List<double>();
                    MyScoring.DizabilitatiScorNivel = new List<double>();
                    MyScoring.ParintiScorNivel = new List<double>();
                    MyScoring.BurseScorNivel = new List<double>();
                    MyScoring.RepetentiScorNivel = new List<double>();
                    MyScoring.OnlineScorNivel = new List<double>();
                    MyScoring.RemedialaScorNivel = new List<double>();

                    MyScoring.RomiScorNivelValue = new List<double>(new double[5]);
                    MyScoring.DizabilitatiScorNivelValue = new List<double>(new double[5]);
                    MyScoring.ParintiScorNivelValue = new List<double>(new double[5]);
                    MyScoring.BurseScorNivelValue = new List<double>(new double[5]);
                    MyScoring.RepetentiScorNivelValue = new List<double>(new double[5]);
                    MyScoring.OnlineScorNivelValue = new List<double>(new double[5]);
                    MyScoring.RemedialaScorNivelValue = new List<double>(new double[5]);

                    MyScoring.RomiScorNivelIndex = new List<string>(new string[5]);
                    MyScoring.DizabilitatiScorNivelIndex = new List<string>(new string[5]);
                    MyScoring.ParintiScorNivelIndex = new List<string>(new string[5]);
                    MyScoring.BurseScorNivelIndex = new List<string>(new string[5]);
                    MyScoring.RepetentiScorNivelIndex = new List<string>(new string[5]);
                    MyScoring.OnlineScorNivelIndex = new List<string>(new string[5]);
                    MyScoring.RemedialaScorNivelIndex = new List<string>(new string[5]);

                    MyScoring.RomiScor2b = new List<double>();
                    MyScoring.DizabilitatiScor2b = new List<double>();
                    MyScoring.ParintiScor2b = new List<double>();
                    MyScoring.BurseScor2b = new List<double>();

                    MyScoring.RomiScor2bValue = new List<double>(new double[5]);
                    MyScoring.DizabilitatiScor2bValue = new List<double>(new double[5]);
                    MyScoring.ParintiScor2bValue = new List<double>(new double[5]);
                    MyScoring.BurseScor2bValue = new List<double>(new double[5]);

                    MyScoring.RomiScor2bIndex = new List<string>(new string[5]);
                    MyScoring.DizabilitatiScor2bIndex = new List<string>(new string[5]);
                    MyScoring.ParintiScor2bIndex = new List<string>(new string[5]);
                    MyScoring.BurseScor2bIndex = new List<string>(new string[5]);


                    foreach (Clasa MyClasa in MyClase)
                    {
                        if (MyClasa.Moderator != "1")
                        {

                            if (MyClasa.Total2bC != null &&
                                MyClasa.Romi2bC != null &&
                                MyClasa.Dizabilitati2bC != null &&
                                MyClasa.Parinti2bC != null &&
                                MyClasa.Burse2bC != null &&
                                MyClasa.Repetenti2bC != null &&
                                MyClasa.Online2bC != null &&
                                MyClasa.Remediala2bC != null &&
                                MyClasa.TotalC != null &&
                                MyClasa.RomiC != null &&
                                MyClasa.DizabilitatiC != null &&
                                MyClasa.ParintiC != null &&
                                MyClasa.BurseC != null &&
                                MyClasa.RepetentiC != null &&
                                MyClasa.OnlineC != null &&
                                MyClasa.RemedialaC != null &&
                                MyClasa.CladireC != null)
                            {
                                double ProcentRomiClasa = Double.Parse(MyClasa.RomiC) / Double.Parse(MyClasa.TotalC) * 100;
                                double ProcentDizabilitatiClasa = (Double.Parse(MyClasa.DizabilitatiC) / Double.Parse(MyClasa.TotalC) * 100);
                                double ProcentParintiClasa = (Double.Parse(MyClasa.ParintiC) / Double.Parse(MyClasa.TotalC) * 100);
                                double ProcentBurseClasa = (Double.Parse(MyClasa.BurseC) / Double.Parse(MyClasa.TotalC) * 100);
                                double ProcentRepetentiClasa = (Double.Parse(MyClasa.RepetentiC) / Double.Parse(MyClasa.TotalC) * 100);
                                double ProcentOnlineClasa = (Double.Parse(MyClasa.OnlineC) / Double.Parse(MyClasa.TotalC) * 100);
                                double ProcentRemedialaClasa = (Double.Parse(MyClasa.RemedialaC) / Double.Parse(MyClasa.TotalC) * 100);

                                if (MyClasa.Cifra != "Mixt")
                                {
                                    MyScoring.RomiScorNivel.Add(Math.Round(Math.Abs(ProcentRomiClasa - (MyScoring.RomiNivel[Int32.Parse(MyClasa.Cifra)] / MyScoring.TotalNivel[Int32.Parse(MyClasa.Cifra)] * 100) ) / 10, 2, MidpointRounding.AwayFromZero));
                                    MyScoring.DizabilitatiScorNivel.Add(Math.Round(Math.Abs(ProcentDizabilitatiClasa - (MyScoring.DizabilitatiNivel[Int32.Parse(MyClasa.Cifra)] / MyScoring.TotalNivel[Int32.Parse(MyClasa.Cifra)] * 100) ) / 10, 2, MidpointRounding.AwayFromZero));
                                    MyScoring.ParintiScorNivel.Add(Math.Round(Math.Abs(ProcentParintiClasa - (MyScoring.ParintiNivel[Int32.Parse(MyClasa.Cifra)] / MyScoring.TotalNivel[Int32.Parse(MyClasa.Cifra)] * 100) ) / 10, 2, MidpointRounding.AwayFromZero));
                                    MyScoring.BurseScorNivel.Add(Math.Round(Math.Abs(ProcentBurseClasa - (MyScoring.BurseNivel[Int32.Parse(MyClasa.Cifra)] / MyScoring.TotalNivel[Int32.Parse(MyClasa.Cifra)] * 100) ) / 10, 2, MidpointRounding.AwayFromZero));
                                    MyScoring.RepetentiScorNivel.Add(Math.Round(Math.Abs(ProcentRepetentiClasa - (MyScoring.RepetentiNivel[Int32.Parse(MyClasa.Cifra)] / MyScoring.TotalNivel[Int32.Parse(MyClasa.Cifra)] * 100) ) / 10, 2, MidpointRounding.AwayFromZero));
                                    MyScoring.OnlineScorNivel.Add(Math.Round(Math.Abs(ProcentOnlineClasa - (MyScoring.OnlineNivel[Int32.Parse(MyClasa.Cifra)] / MyScoring.TotalNivel[Int32.Parse(MyClasa.Cifra)] * 100) ) / 10, 2, MidpointRounding.AwayFromZero));
                                    MyScoring.RemedialaScorNivel.Add(Math.Round(Math.Abs(ProcentRemedialaClasa - (MyScoring.RemedialaNivel[Int32.Parse(MyClasa.Cifra)] / MyScoring.TotalNivel[Int32.Parse(MyClasa.Cifra)] * 100) ) / 10, 2, MidpointRounding.AwayFromZero));
                                }

                                MyScoring.RomiScor2b.Add(Math.Round(Math.Abs((Double.Parse(MyClasa.Romi2bC) / Double.Parse(MyClasa.Total2bC) * 100) - ProcentRomiClasa) / 10, 2, MidpointRounding.AwayFromZero));
                                MyScoring.DizabilitatiScor2b.Add(Math.Round(Math.Abs((Double.Parse(MyClasa.Dizabilitati2bC) / Double.Parse(MyClasa.Total2bC) * 100) - ProcentDizabilitatiClasa) / 10, 2, MidpointRounding.AwayFromZero));
                                MyScoring.ParintiScor2b.Add(Math.Round(Math.Abs((Double.Parse(MyClasa.Parinti2bC) / Double.Parse(MyClasa.Total2bC) * 100) - ProcentParintiClasa) / 10, 2, MidpointRounding.AwayFromZero));
                                MyScoring.BurseScor2b.Add(Math.Round(Math.Abs((Double.Parse(MyClasa.Burse2bC) / Double.Parse(MyClasa.Total2bC) * 100) - ProcentBurseClasa) / 10, 2, MidpointRounding.AwayFromZero));
                            }

                        }
                    }

                    if (MyScoring.RomiScorNivel.Count() > 0)
                    {
                        var result = MyScoring.RomiScorNivel.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorA4 = MyScoring.RomiScorNivel.Max();
                        for (int i = 0; i<result.Count(); i++)
                        {
                            MyScoring.RomiScorNivelValue[i] = result[i].v;
                            MyScoring.RomiScorNivelIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorA4 = 0;

                    if (MyScoring.DizabilitatiScorNivel.Count() > 0)
                    {
                        var result = MyScoring.DizabilitatiScorNivel.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorB4 = MyScoring.DizabilitatiScorNivel.Max();
                        for (int i = 0; i < result.Count(); i++)
                        {
                            MyScoring.DizabilitatiScorNivelValue[i] = result[i].v;
                            MyScoring.DizabilitatiScorNivelIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorB4 = 0;

                    if (MyScoring.ParintiScorNivel.Count() > 0)
                    {
                        var result = MyScoring.ParintiScorNivel.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorC4 = MyScoring.ParintiScorNivel.Max();
                        for (int i = 0; i < result.Count(); i++)
                        {
                            MyScoring.ParintiScorNivelValue[i] = result[i].v;
                            MyScoring.ParintiScorNivelIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorC4 = 0;

                    if (MyScoring.BurseScorNivel.Count() > 0)
                    {
                        var result = MyScoring.BurseScorNivel.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorC9 = MyScoring.BurseScorNivel.Max();
                        for (int i = 0; i < result.Count(); i++)
                        {
                            MyScoring.BurseScorNivelValue[i] = result[i].v;
                            MyScoring.BurseScorNivelIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorC9 = 0;

                    if (MyScoring.RepetentiScorNivel.Count() > 0)
                    {
                        var result = MyScoring.RepetentiScorNivel.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorD1 = MyScoring.RepetentiScorNivel.Max();
                        for (int i = 0; i < result.Count(); i++)
                        {
                            MyScoring.RepetentiScorNivelValue[i] = result[i].v;
                            MyScoring.RepetentiScorNivelIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorD1 = 0;

                    if (MyScoring.OnlineScorNivel.Count() > 0)
                    {
                        var result = MyScoring.OnlineScorNivel.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorD2 = MyScoring.OnlineScorNivel.Max();
                        for (int i = 0; i < result.Count(); i++)
                        {
                            MyScoring.OnlineScorNivelValue[i] = result[i].v;
                            MyScoring.OnlineScorNivelIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorD2 = 0;

                    if (MyScoring.RemedialaScorNivel.Count() > 0)
                    {
                        var result = MyScoring.RemedialaScorNivel.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorD3 = MyScoring.RemedialaScorNivel.Max();
                        for (int i = 0; i < result.Count(); i++)
                        {
                            MyScoring.RemedialaScorNivelValue[i] = result[i].v;
                            MyScoring.RemedialaScorNivelIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorD3 = 0;

                    if (MyScoring.RomiScor2b.Count() > 0)
                    {
                        var result = MyScoring.RomiScor2b.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorA5 = MyScoring.RomiScor2b.Max();
                        for (int i = 0; i < result.Count(); i++)
                        {
                            MyScoring.RomiScor2bValue[i] = result[i].v;
                            MyScoring.RomiScor2bIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorA5 = 0;

                    if (MyScoring.DizabilitatiScor2b.Count() > 0)
                    {
                        var result = MyScoring.DizabilitatiScor2b.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorB5 = MyScoring.DizabilitatiScor2b.Max();
                        for (int i = 0; i < result.Count(); i++)
                        {
                            MyScoring.DizabilitatiScor2bValue[i] = result[i].v;
                            MyScoring.DizabilitatiScor2bIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorB5 = 0;

                    if (MyScoring.ParintiScor2b.Count() > 0)
                    {
                        var result = MyScoring.ParintiScor2b.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorC5 = MyScoring.ParintiScor2b.Max();
                        for (int i = 0; i < result.Count(); i++)
                        {
                            MyScoring.ParintiScor2bValue[i] = result[i].v;
                            MyScoring.ParintiScor2bIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorC5 = 0;

                    if (MyScoring.BurseScor2b.Count() > 0)
                    {
                        var result = MyScoring.BurseScor2b.Select((v, i) => new { v, i }).OrderByDescending(x => x.v).ThenByDescending(x => x.i).Take(5).ToArray();
                        MyScoring.ScorC10 = MyScoring.BurseScor2b.Max();
                        for (int i = 0; i < result.Count(); i++)
                        {
                            MyScoring.BurseScor2bValue[i] = result[i].v;
                            MyScoring.BurseScor2bIndex[i] = MyClase[result[i].i].CifraC + MyClase[result[i].i].LiteraC;
                        }
                    }
                    else MyScoring.ScorC10 = 0;


                    switch (MyScoring.JudetS)
                    {
                        case "B":
                            MyScoring.JudetS = "Bucuresti";
                            break;
                        case "BT":
                            MyScoring.JudetS = "Botosani";
                            break;
                        case "BV":
                            MyScoring.JudetS = "Brasov";
                            break;
                        case "CJ":
                            MyScoring.JudetS = "Cluj";
                            break;
                        case "CT":
                            MyScoring.JudetS = "Constanta";
                            break;
                        case "IL":
                            MyScoring.JudetS = "Ialomita";
                            break;
                        case "IS":
                            MyScoring.JudetS = "Iasi";
                            break;
                        case "MM":
                            MyScoring.JudetS = "Maramures";
                            break;
                        case "MS":
                            MyScoring.JudetS = "Mures";
                            break;
                        case "PH":
                            MyScoring.JudetS = "Prahova";
                            break;
                        case "SV":
                            MyScoring.JudetS = "Suceava";
                            break;
                        default:
                            break;
                    }

                    MyScores.Add(MyScoring);
                }
            }
            return MyScores;
        }

        [HttpGet("chestionar")]
        public List<Chestionar> GetChestionar()
        {
            IEnumerable<Scoala> AllScoli = IScoalaRepository.GetAll();
            List<Unitate> AllUnitati = IUnitateRepository.GetAll().OrderBy(o => o.ScoalaId).ThenByDescending(o => o.Statut).ToList();
            IEnumerable<Clasa> AllClase = IClasaRepository.GetAll();
            IEnumerable<MonitorIntrebare> AllMonitorIntrebari = IMonitorIntrebareRepository.GetAll();
            IEnumerable<Monitor> AllMonitori = IMonitorRepository.GetAll();

            List<Chestionar> MyChests = new List<Chestionar>();

            string tLocalitate = "";
            foreach (Unitate MyUnitate in AllUnitati)
            {
                if (MyUnitate.Moderator != "1")
                {

                    Chestionar MyChestionar = new Chestionar();
                    Scoala TempScoala = AllScoli.Where(x => x.Id == MyUnitate.ScoalaId).FirstOrDefault();
                    if (MyUnitate.Statut == "PJ")
                    {
                        tLocalitate = MyUnitate.Localitate;
                    }

                    MyChestionar.NumeScoala = TempScoala.Nume;
                    MyChestionar.JudetS = TempScoala.Judet;
                    MyChestionar.LocalitateS = tLocalitate;

                    MyChestionar.NumeU = MyUnitate.Nume;
                    MyChestionar.IdChestionar = MyUnitate.Id-1597;
                    MyChestionar.StatutU = MyUnitate.Statut;

                    MyChestionar.NrDep = TempScoala.NrInreg;
                    MyChestionar.NrDepC = TempScoala.NrInregC;
                    MyChestionar.ScoalaId = MyUnitate.ScoalaId;
                    MyChestionar.PathChestionar = MyUnitate.PathChestionar;

                    IEnumerable<MonitorIntrebare> MyMonitorIntrebari = AllMonitorIntrebari.Where(x => x.Unitate == MyUnitate.Id);
                    if (MyMonitorIntrebari.Count() > 0)
                    {
                        int cineId = MyMonitorIntrebari.FirstOrDefault().MonitorId;
                        Monitor cine = AllMonitori.Where(x => x.Id == cineId).FirstOrDefault();
                        MyChestionar.MonitorNume = cine.Email;
                        MyChestionar.Raspuns51a = MyMonitorIntrebari.Where(x => x.IntrebareId == 51).FirstOrDefault().Raspuns;
                        MyChestionar.Raspuns51b = MyMonitorIntrebari.Where(x => x.IntrebareId == 51).FirstOrDefault().Raspuns2;
                        MyChestionar.Raspuns51c = MyMonitorIntrebari.Where(x => x.IntrebareId == 51).FirstOrDefault().Raspuns3;
                        MyChestionar.Raspuns51d = MyMonitorIntrebari.Where(x => x.IntrebareId == 51).FirstOrDefault().Raspuns4;

                        MyChestionar.Raspuns52a = MyMonitorIntrebari.Where(x => x.IntrebareId == 52).FirstOrDefault().Raspuns;
                        MyChestionar.Raspuns52b = MyMonitorIntrebari.Where(x => x.IntrebareId == 52).FirstOrDefault().Raspuns2;
                        MyChestionar.Raspuns52c = MyMonitorIntrebari.Where(x => x.IntrebareId == 52).FirstOrDefault().Raspuns3;
                        MyChestionar.Raspuns52d = MyMonitorIntrebari.Where(x => x.IntrebareId == 52).FirstOrDefault().Raspuns4;

                        MyChestionar.Raspuns53a = MyMonitorIntrebari.Where(x => x.IntrebareId == 53).FirstOrDefault().Raspuns;
                        MyChestionar.Raspuns53b = MyMonitorIntrebari.Where(x => x.IntrebareId == 53).FirstOrDefault().Raspuns2;
                        MyChestionar.Raspuns53c = MyMonitorIntrebari.Where(x => x.IntrebareId == 53).FirstOrDefault().Raspuns3;
                        MyChestionar.Raspuns53d = MyMonitorIntrebari.Where(x => x.IntrebareId == 53).FirstOrDefault().Raspuns4;

                        MyChestionar.Raspuns54 = MyMonitorIntrebari.Where(x => x.IntrebareId == 54).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns55 = MyMonitorIntrebari.Where(x => x.IntrebareId == 55).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns56 = MyMonitorIntrebari.Where(x => x.IntrebareId == 56).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns58 = MyMonitorIntrebari.Where(x => x.IntrebareId == 58).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns59 = MyMonitorIntrebari.Where(x => x.IntrebareId == 59).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns60a = MyMonitorIntrebari.Where(x => x.IntrebareId == 60).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns60b = MyMonitorIntrebari.Where(x => x.IntrebareId == 60).FirstOrDefault().Raspuns2;

                        MyChestionar.Raspuns61 = MyMonitorIntrebari.Where(x => x.IntrebareId == 61).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns62 = MyMonitorIntrebari.Where(x => x.IntrebareId == 62).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns63 = MyMonitorIntrebari.Where(x => x.IntrebareId == 63).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns64 = MyMonitorIntrebari.Where(x => x.IntrebareId == 64).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns65 = MyMonitorIntrebari.Where(x => x.IntrebareId == 65).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns68a = MyMonitorIntrebari.Where(x => x.IntrebareId == 68).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns68b = MyMonitorIntrebari.Where(x => x.IntrebareId == 68).FirstOrDefault().Raspuns2;

                        MyChestionar.Raspuns69 = MyMonitorIntrebari.Where(x => x.IntrebareId == 69).FirstOrDefault().Raspuns;

                        MyChestionar.Raspuns70 = MyMonitorIntrebari.Where(x => x.IntrebareId == 70).FirstOrDefault().Raspuns;
                    }







                    switch (MyChestionar.JudetS)
                    {
                        case "B":
                            MyChestionar.JudetS = "Bucuresti";
                            break;
                        case "BT":
                            MyChestionar.JudetS = "Botosani";
                            break;
                        case "BV":
                            MyChestionar.JudetS = "Brasov";
                            break;
                        case "CJ":
                            MyChestionar.JudetS = "Cluj";
                            break;
                        case "CT":
                            MyChestionar.JudetS = "Constanta";
                            break;
                        case "IL":
                            MyChestionar.JudetS = "Ialomita";
                            break;
                        case "IS":
                            MyChestionar.JudetS = "Iasi";
                            break;
                        case "MM":
                            MyChestionar.JudetS = "Maramures";
                            break;
                        case "MS":
                            MyChestionar.JudetS = "Mures";
                            break;
                        case "PH":
                            MyChestionar.JudetS = "Prahova";
                            break;
                        case "SV":
                            MyChestionar.JudetS = "Suceava";
                            break;
                        default:
                            break;
                    }

                    MyChests.Add(MyChestionar);
                }
            }
            return MyChests;
        }

        [HttpGet("{id}")]
        public UnitateDetailsDTO Get(int id)
        {
            Unitate Unitate = IUnitateRepository.Get(id);
            UnitateDetailsDTO MyUnitate = new UnitateDetailsDTO()
            {
                Localitate = Unitate.Localitate,
                Nume = Unitate.Nume,
                Statut = Unitate.Statut,
                Nivel = Unitate.Nivel,
                NivelC = Unitate.NivelC,
                Strada = Unitate.Strada,
                NrStrada = Unitate.NrStrada,
                CodPostal = Unitate.CodPostal,
                Telefon = Unitate.Telefon,
                Fax = Unitate.Fax,
                Total = Unitate.Total,
                Romi = Unitate.Romi,
                Dizabilitati = Unitate.Dizabilitati,
                Parinti = Unitate.Parinti,
                Burse = Unitate.Burse,
                Repetenti = Unitate.Repetenti,
                Online = Unitate.Online,
                Remediala = Unitate.Remediala,
                ScoalaId = Unitate.ScoalaId,
                PathChestionar = Unitate.PathChestionar,
                NrCladiri = Unitate.NrCladiri,
                TotalC = Unitate.TotalC,
                RomiC = Unitate.RomiC,
                RomiE = Unitate.RomiE,
                DizabilitatiC = Unitate.DizabilitatiC,
                ParintiC = Unitate.ParintiC,
                BurseC = Unitate.BurseC,
                RepetentiC = Unitate.RepetentiC,
                OnlineC = Unitate.OnlineC,
                RemedialaC = Unitate.RemedialaC,
                NrCladiriC = Unitate.NrCladiriC,
                Moderator = Unitate.Moderator
            };
            IEnumerable<Clasa> MyClase = IClasaRepository.GetAll().Where(x => x.UnitateId == Unitate.Id);
            if (MyClase != null)
            {
                List<string> NumeClaseList = new List<string>();
                List<string> NumeClaseList1 = new List<string>();
                List<string> NumeClaseList2 = new List<string>();
                List<string> NumeClaseListC = new List<string>();
                List<string> NumeClaseList1C = new List<string>();
                List<string> NumeClaseList2C = new List<string>();
                List<int> IdClaseList = new List<int>();
                List<int> IdClaseList1 = new List<int>();
                List<int> IdClaseList2 = new List<int>();
                List<string> CountClaseList = new List<string>() { "", "", "", "", "", "", "", "", "", "" };
                List<string> CountClaseList1 = new List<string>() { "", "", "", "", "", "", "", "", "", "" };
                List<string> CountClaseList2 = new List<string>() { "", "", "", "", "", "", "", "", "", "" };
                List<string> ModeratorClaseList = new List<string>();
                if (MyClase.Count() != 0)
                {
                    CountClaseList = new List<string>() { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                    CountClaseList1 = new List<string>() { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                    CountClaseList2 = new List<string>() { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                }
                foreach (Clasa MyClasa in MyClase)
                {
                    ModeratorClaseList.Add(MyClasa.Moderator);

                    if (MyClasa.Moderator == "0") NumeClaseList.Add(MyClasa.Cifra + MyClasa.Litera);
                    if (MyClasa.Moderator == "1") NumeClaseList1.Add(MyClasa.Cifra + MyClasa.Litera);
                    if (MyClasa.Moderator == "2") NumeClaseList2.Add(MyClasa.Cifra + MyClasa.Litera);
                    if (MyClasa.Moderator == "0") NumeClaseListC.Add(MyClasa.Cifra + MyClasa.LiteraC);
                    if (MyClasa.Moderator == "1") NumeClaseList1C.Add(MyClasa.Cifra + MyClasa.LiteraC);
                    if (MyClasa.Moderator == "2") NumeClaseList2C.Add(MyClasa.Cifra + MyClasa.LiteraC);


                    if (MyClasa.Moderator == "0") IdClaseList.Add(MyClasa.Id);
                    if (MyClasa.Moderator == "1") IdClaseList1.Add(MyClasa.Id);
                    if (MyClasa.Moderator == "2") IdClaseList2.Add(MyClasa.Id);


                    if (MyClasa.Cifra == "Mixt")
                    {
                        if (MyClasa.Moderator == "0") CountClaseList[9] = (Int32.Parse(CountClaseList[9]) + 1).ToString();
                        if (MyClasa.Moderator == "1") CountClaseList1[9] = (Int32.Parse(CountClaseList1[9]) + 1).ToString();
                        if (MyClasa.Moderator == "2") CountClaseList2[9] = (Int32.Parse(CountClaseList2[9]) + 1).ToString();
                    }
                    else
                    {
                        int cifra = Int32.Parse(MyClasa.Cifra);
                        if (MyClasa.Moderator == "0") CountClaseList[cifra] = (Int32.Parse(CountClaseList[cifra]) + 1).ToString();
                        if (MyClasa.Moderator == "1") CountClaseList1[cifra] = (Int32.Parse(CountClaseList1[cifra]) + 1).ToString();
                        if (MyClasa.Moderator == "2") CountClaseList2[cifra] = (Int32.Parse(CountClaseList2[cifra]) + 1).ToString();
                    }
                }
                MyUnitate.ClasaNume = NumeClaseList;
                MyUnitate.ClasaNume1 = NumeClaseList1;
                MyUnitate.ClasaNume2 = NumeClaseList2;
                MyUnitate.ClasaNumeC = NumeClaseListC;
                MyUnitate.ClasaNume1C = NumeClaseList1C;
                MyUnitate.ClasaNume2C = NumeClaseList2C;


                MyUnitate.ClasaId = IdClaseList;
                MyUnitate.ClasaId1 = IdClaseList1;
                MyUnitate.ClasaId2 = IdClaseList2;


                MyUnitate.ClasaCount = CountClaseList;
                MyUnitate.ClasaCount1 = CountClaseList1;
                MyUnitate.ClasaCount2 = CountClaseList2;

                MyUnitate.ClasaModerator = ModeratorClaseList;
            }
            return MyUnitate;
        }

        [HttpPost]
        public Unitate Post(UnitateDTO value)
        {
            Unitate model = new Unitate
            {
                Localitate = value.Localitate,
                Nume = value.Nume,
                Statut = value.Statut,
                Nivel = value.Nivel,
                NivelC = value.NivelC,
                Strada = value.Strada,
                NrStrada = value.NrStrada,
                CodPostal = value.CodPostal,
                Telefon = value.Telefon,
                Fax = value.Fax,
                Total = value.Total,
                Romi = value.Romi,
                Dizabilitati = value.Dizabilitati,
                Parinti = value.Parinti,
                Burse = value.Burse,
                Repetenti = value.Repetenti,
                Online = value.Online,
                Remediala = value.Remediala,
                ScoalaId = value.ScoalaId,
                PathChestionar = value.PathChestionar,
                NrCladiri = value.NrCladiri,
                TotalC = value.TotalC,
                RomiC = value.RomiC,
                RomiE = value.RomiE,
                DizabilitatiC = value.DizabilitatiC,
                ParintiC = value.ParintiC,
                BurseC = value.BurseC,
                RepetentiC = value.RepetentiC,
                OnlineC = value.OnlineC,
                RemedialaC = value.RemedialaC,
                NrCladiriC = value.NrCladiriC,
                Moderator = value.Moderator
            };
            return IUnitateRepository.Create(model);

        }

        [HttpPut("{id}")]
        public Unitate Put(int id, UnitateDTO value)
        {
            Unitate model = IUnitateRepository.Get(id);
            if (value.Localitate != null)
            {
                model.Localitate = value.Localitate;
            }
            if (value.Nume != null)
            {
                model.Nume = value.Nume;
            }
            if (value.Statut != null)
            {
                model.Statut = value.Statut;
            }
            if (value.Nivel != null)
            {
                model.Nivel = value.Nivel;
            }
            if (value.NivelC != null)
            {
                model.NivelC = value.NivelC;
            }
            if (value.Strada != null)
            {
                model.Strada = value.Strada;
            }
            if (value.NrStrada != null)
            {
                model.NrStrada = value.NrStrada;
            }
            if (value.CodPostal != null)
            {
                model.CodPostal = value.CodPostal;
            }
            if (value.Telefon != null)
            {
                model.Telefon = value.Telefon;
            }
            if (value.Fax != null)
            {
                model.Fax = value.Fax;
            }
            if (value.Total != null)
            {
                model.Total = value.Total;
            }
            if (value.Romi != null)
            {
                model.Romi = value.Romi;
            }
            if (value.Dizabilitati != null)
            {
                model.Dizabilitati = value.Dizabilitati;
            }
            if (value.Parinti != null)
            {
                model.Parinti = value.Parinti;
            }
            if (value.Online != null)
            {
                model.Online = value.Online;
            }
            if (value.Burse != null)
            {
                model.Burse = value.Burse;
            }
            if (value.Repetenti != null)
            {
                model.Repetenti = value.Repetenti;
            }
            if (value.Remediala != null)
            {
                model.Remediala = value.Remediala;
            }
            if (value.ScoalaId != 0)
            {
                model.ScoalaId = value.ScoalaId;
            }
            if (value.PathChestionar != null)
            {
                model.PathChestionar = value.PathChestionar;
            }
            if (value.NrCladiri != 0)
            {
                model.NrCladiri = value.NrCladiri;
            }
            if (value.TotalC != null)
            {
                model.TotalC = value.TotalC;
            }
            if (value.RomiC != null)
            {
                model.RomiC = value.RomiC;
            }
            if (value.RomiE != null)
            {
                model.RomiE = value.RomiE;
            }
            if (value.DizabilitatiC != null)
            {
                model.DizabilitatiC = value.DizabilitatiC;
            }
            if (value.ParintiC != null)
            {
                model.ParintiC = value.ParintiC;
            }
            if (value.OnlineC != null)
            {
                model.OnlineC = value.OnlineC;
            }
            if (value.BurseC != null)
            {
                model.BurseC = value.BurseC;
            }
            if (value.RepetentiC != null)
            {
                model.RepetentiC = value.RepetentiC;
            }
            if (value.RemedialaC != null)
            {
                model.RemedialaC = value.RemedialaC;
            }
            if (value.NrCladiriC != 0)
            {
                model.NrCladiriC = value.NrCladiriC;
            }
            if (value.Moderator != null)
            {
                model.Moderator = value.Moderator;
            }
            return IUnitateRepository.Update(model);
        }

        [HttpDelete("{id}")]
        public Unitate Delete(int id)
        {
            Unitate model = IUnitateRepository.Get(id);
            return IUnitateRepository.Delete(model);
        }
    }
}
