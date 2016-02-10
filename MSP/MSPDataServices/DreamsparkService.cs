using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSP.Services;

namespace MSP.MSPDataServices
{
    public class DreamsparkService : IDreamsparkService
    {
        public string GetBriefDescription()
        {
            StringBuilder _description = new StringBuilder();
            _description.Append("Microsoft, prin programul DreamSpark Premium, oferă acces la tehnologie tuturor studenților: Windows 8, Windows 7 Professional, Windows Vista Business, Visual Studio 2012, Windows Server 2012, SQL Server 2012, Exchange Server si multe altele sunt disponibile gratuit. Programul se adresează oricărui student, masterand sau doctorand, din cadrul Facultății de Automatică și Calculatoare, Facultății de Inginerie în Limbi Străine.");
            return _description.ToString();
        }

        public string GetDescription()
        {
            StringBuilder _description = new StringBuilder();
            _description.Append(GetBriefDescription());
            _description.Append("\n");
            _description.Append("Singura restricție asupra produselor descărcate este că nu pot fi utilizate în scop comercial. Mai multe informații despre modul de folosire al aplicațiilor descărcăte prin intermediul programului DreamSpark Premium, vă rugăm să citiți cu atenție informațiile de pe site-ul https://www.dreamspark.com/");
            _description.Append("\n");
            _description.Append("Studenții care părăsesc facultățile ce au acces soft gratuit, nu mai beneficiază de acest program deoarece conturile folosite pentru accesul la software expiră anual. Aceasta nu înseamnă ca software-ul deja descărcat nu mai poate fi folosit, ci că nu se mai poate descărca unul nou. Astfel, este recomandată descărcarea tuturor aplicațiilor dorite înainte de terminarea studiilor.");
            return _description.ToString();
        }


        public string GetAuthentication1()
        {
            StringBuilder _authentication = new StringBuilder();
            _authentication.Append("Fiecare student de la Automatică şi Calculatoare deţine o adresă de email de forma prenume.nume@aut.pub.ro (pentru Automatică - licenţă) sau prenume.nume@cti.pub.ro (pentru Calculatoare şi master, indiferent de specializare). Aceste conturi se pot accesa la adresa http://outlook.com şi au parola iniţială studXXXXXX (XXXXXX reprezintă ultimele 6 cifre din CNP).");
            return _authentication.ToString();
        }

        public string GetAuthentication2()
        {
            StringBuilder _authentication = new StringBuilder();
            _authentication.Append("\n");
            _authentication.Append("Fii atent după un e-mail primit din partea E-Academy, în care vor fi menţionate username-ul şi parola necesare autentificării pe site-ul de unde îţi poţi alege licenţele.");
            _authentication.Append("\n");
            _authentication.Append("Accesează oricare din cele 2 link-uri de mai jos:");
            _authentication.Append("\n");
            _authentication.Append("   • http://microsoft.pub.ro/msdnaa");
            _authentication.Append("\n");
            _authentication.Append("   • http://microsoft.pub.ro/softgratuit");
            _authentication.Append("\n");
            _authentication.Append("Autentifică-te cu credenţialele obţinute din mail-ul primit din partea E-Academy, după care îţi poţi alege software-ul dorit.");
            return _authentication.ToString();
        }


        public string GetImage1Url()
        {
            return "http://www.microsoft.pub.ro/Media/Default/Page/drm1.jpg";
        }

        public string GetImage2Url()
        {
            return "http://www.microsoft.pub.ro/Media/Default/Page/drm2.jpg";
        }

        public string GetImage3Url()
        {
            return "http://www.microsoft.pub.ro/Media/Default/Page/drm3.jpg";
        }

        public string GetDownload1()
        {
            return "Unele programe au mai multe versiuni. Astfel, pe urmatoarea pagină, ar trebui să alegi aplicaţia dorită şi, în final, continuarea se face prin butonul <Add to cart>.";
        }

        public string GetDownloadImage1()
        {
            return "http://www.microsoft.pub.ro/Media/Default/Page/drm4.jpg";
        }

        public string GetDownload2()
        {
            return "\nPe urmatoarea pagină vei afla ce conţine coşul în acel moment. Şi vei avea fie opţiunea de a continua să iei licenţe şi să umpli coşul, prin butonul de <Continue Shopping>, fie să dai <Check Out> şi să treci la următorul pas.";
        }

        public string GetDownloadImage2()
        {
            return "http://www.microsoft.pub.ro/Media/Default/Page/drm6.jpg";
        }

        public string GetDownload3()
        {
            return "\nDupă Check Out trebuie să accepţi EULA după care îţi va apărea un sumar al licenţelor si va trebui să completezi câteva informaţii.";
        }

        public string GetDownloadImage3()
        {
            return "http://www.microsoft.pub.ro/Media/Default/Page/drm8.jpg";
        }

        public string GetDownload4()
        {
            return "\nDupă ce apăsaţi pe <Proceed with Order>, pe următoarea pagină vor fi generate licenţele. Tot aici, ai şi opţiunea de a descărca programul prin butonul de <Download Options>.";
        }

        public string GetDownloadImage4()
        {
            return "http://www.microsoft.pub.ro/Media/Default/Page/drm9.jpg";
        }

        public string GetInstall()
        {
            StringBuilder _install = new StringBuilder();
            _install.Append("Pentru instalarea programului se poate:");
            _install.Append("\n\n");
            _install.Append("1. Scrie imaginea pe un CD/DVD, care va fi folosit la instalare. (variantă recomandată)");
            _install.Append("\n");
            _install.Append("2. Monta fișierul *.iso într-un drive CD/DVD virtual.");
            _install.Append("\n");
            _install.Append("Atât pentru a scrie imaginea pe un CD/DVD, cât și pentru a instala un drive virtual, se recomandă aplicația PowerISO.");
            return _install.ToString();
        }

        public string GetRecommendation()
        {
            StringBuilder _recommendation = new StringBuilder();
            _recommendation.Append("Fiecare utilizator al programului DreamSpark trebuie să citească acest ghid simplificat de utilizare.");
            _recommendation.Append("\n");
            _recommendation.Append("Fiecare dintre soft-urile disponibile se poate descărca de un numar limitat de ori. Este recomandat să păstrezi imaginea în format ISO, obținută în urma descărcării, pentru a o putea utiliza în viitor. Pentru orice probleme referitoare la subscriptia de MSDNAA, vă rugam să dati un e-mail catre softgratuit@microsoft.pub.ro. Veți primi un raspuns în maxim 48 ore, sau puteți să ne faceți o vizita în Microsoft Innovation Center din corpul Energetica, sala EG101 și să discutam personal.");
            return _recommendation.ToString();
        }
    }
}
