using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSP.Services;

namespace MSP.MSPDataServices
{
    public class ImagineCupService : IImagineCupService
    {
        public string GetDescription()
        {
            StringBuilder _description = new StringBuilder();
            _description.Append("O competiţie globală destinată studenţilor. Cifre pentru ediţia precendentă? 183 de ţări. Peste 1.4 milioane de studenţi (dintre care 7000 de români).");
            return _description.ToString();
        }

        public string GetReasons()
        {
            StringBuilder _reasons = new StringBuilder();
            _reasons.Append("• vizibilitate: toată lumea va afla de proiectul tău\n");
            _reasons.Append("\n");
            _reasons.Append("• oportunităţi de carieră: fiind un concurs internaţional foarte cunoscut, obţinerea unui premiu poate face diferenţa între târât cu CV-ul pe bestjobs sau o acceptare imediată; mai apoi, unii finalişti s-au angajat direct la Microsoft!\n");
            _reasons.Append("\n");
            _reasons.Append("• finanţare implementare: finaliştii vor participa la o selecţie în urma căreia Microsoft va finanţa lansarea pe piaţă a proiectelor câştigătoare\n");
            _reasons.Append("\n");
            _reasons.Append("• bani: Vezi „cu ce mă aleg”\n");
            _reasons.Append("\n");
            _reasons.Append("• excursie în Rusia: pentru toţi finaliştii. Sankt Petersburg, mai exact, în iulie 2013.");
            return _reasons.ToString();
        }

        public string GetPrizes()
        {
            StringBuilder _prizes = new StringBuilder();
            _prizes.Append("Premiile se acordă per competiţie şi per provocare.\n");
            _prizes.Append("\n");
            _prizes.Append("Competiţii:\n");
            _prizes.Append("   • Locul I : 50.000$\n");
            _prizes.Append("   • Locul II: 10.000$\n");
            _prizes.Append("   • Locul III: 5.000$\n");
            _prizes.Append("Provocări:\n");
            _prizes.Append("   • Locul I : 10.000$\n");
            _prizes.Append("   • Locul II: 5.000$\n");
            _prizes.Append("   • Locul III: 3.000$\n");
            return _prizes.ToString();
        }

        public string GetGrants()
        {
            StringBuilder _grants = new StringBuilder();
            _grants.Append("Permit finanţarea proiectului tău în vederea vânzării soluţiei tale. Desigur, proiectul tău va trebui să ajute la rezolvarea unei probleme globale critice.\n");
            _grants.Append("Câştigătorii se numără printre finalişti şi vor fi anunţaţi la finele lui 2013.");
            return _grants.ToString();
        }

        public string GetHowToParticipate()
        {
            StringBuilder _howTo = new StringBuilder();
            _howTo.Append("1. Faci rost de o idee.\n");
            _howTo.Append("   • Restricţii? Nu prea. Doar că e musai să folosească o tehnologie Microsoft şi să respecte categoria competiţiei.\n");
            _howTo.Append("\n");
            _howTo.Append("2. Găseşti un mentor.\n");
            _howTo.Append("   • Poţi veni la noi pentru asta. Ne găseşti la imaginecup@microsoft.pub.ro sau în sala EG101.\n");
            _howTo.Append("\n");
            _howTo.Append("3. Îţi formezi o echipă.\n");
            _howTo.Append("\n");
            _howTo.Append("4. Te înscrii pe site.\n");
            _howTo.Append("   • Fiecare membru (inclusiv mentorul) se înscrie pe site (www.imaginecup.com).\n");
            _howTo.Append("\n");
            _howTo.Append("5. Îţi transformi ideea în realitate.\n");
            _howTo.Append("   • Cum? Ajutat de coechipieri şi mentor.");
            return _howTo.ToString();
        }

        public string GetParticipation()
        {
            StringBuilder _participation = new StringBuilder();
            _participation.Append("Ideea ca idee, dar cum o valorific?\n");
            _participation.Append("Există două categorii de concurs: competiţii şi provocări.\n");
            _participation.Append("\n");
            _participation.Append("1. Competiţii\n");
            _participation.Append("   • Inovaţie: Schimbă viaţa oamenilor cu o aplicaţie! Gândeşte, scrie şi testează-ţi aplicaţia revoluţionară.\n");
            _participation.Append("   • Jocuri: Reinventează modul în care ne jucăm! Lansează un joc pentru platforme multiple pentru impact maxim.\n");
            _participation.Append("   • Cetăţenie globală: Ce problemă globală a lumii o poţi rezolva cu tehnologia? Pune-ţi capul la contribuţie şi câsţigă!\n");
            _participation.Append("\n");
            _participation.Append("2. Provocări\n");
            _participation.Append("   • Aplicaţii Windows 8\n");
            _participation.Append("   • Aplicaţii Azure\n");
            _participation.Append("   • Aplicaţii Windows Phone 8\n");
            return _participation.ToString();
        }

        public string GetDeadline()
        {
            StringBuilder _dealine = new StringBuilder();
            _dealine.Append("Competiţii: 15 martie 2013\n");
            _dealine.Append("Provocări: 15 ianuarie 2013 > quiz calificare.");
            return _dealine.ToString();
        }

        public string GetImageUrl()
        {
            StringBuilder _imageUrl = new StringBuilder();
            _imageUrl.Append("http://www.microsoft.pub.ro/Media/Default/Images/Logo.jpg");
            return _imageUrl.ToString();
            
        }
    }
}
