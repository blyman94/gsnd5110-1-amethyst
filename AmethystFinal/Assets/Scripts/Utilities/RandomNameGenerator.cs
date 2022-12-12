using UnityEngine;

/// <summary>
/// Static class to randomly generate a name.
/// </summary>
public static class RandomNameGenerator
{
    private const string FirstNames =
        "Ahmed,Alexander,Ali,Archie,Alice,Amahle,Ayesha,Anna,Benjamin,Brian,Bharata,Bin,Barbara,Birgitta,Brenda,Blanca,Carlos,Charles,Chao,Cesar,Charlotte,Carmen,Claudia,Cynthia,David,Dmitriy,Dinesh,Dilip,Daria,Diana,Donna,Dorothy,Emmanuel,Elijah,Ermias,Eduardo,Emani,Emily,Emika,Elena,Francesco,Fernando,Faisal,Frank,Fatimah,Francisca,Florence,Farzana,Gabriel,Gang,Gul,Giuseppe,Grace,Gloria,Gita,Gustavo,Gabriela,Hiroshi,Hugo,Hui,Hassan,Harper,Halimah,Helen,Hedwig,Ivan,Ibrahim,Ismail,Igor,Isabella,Isla,Irina,Ingrid,Jake,Jose,Junior,Jianhua,Jenny,Juliana,Jade,Jessica,Kyaw,Kai,Kevin,Kamal,Kokoro,Karen,Krishna,Khadija,Leonardo,Liam,Li,Lakshmi,Layla,Lucia,Lin,Luz,Mohammed,Mason,Mateo,Min,Maria,Mariam,Mia,Mary,Noah,Nozomi,Nur,Ning,Nushi,Natalya,Nancy,Nirmala,Oliver,Omar,Osman,Oleg,Olivia,Olga,Oksana,Olha,Peter,Ping,Paulo,Pavel,Precious,Princess,Pushpa,Pamela,Qing,Quan,Qun,Qiong,Raphael,Robert,Ram,Ricardo,Rosa,Rita,Rekha,Rebecca,Santiago,Sekani,Sri,Sergey,Saanvi,Sofie,Sarah,Svetlana,Thomas,Tuan,Timothy,Tong,Tamar,Theodora,Teresa,Tamara,Usman,Umar,Umesh,Ursula,Ura,Uma,Victor,Vladimir,Vijay,Vicente,Vivian,Victoria,Veronica,Vera,Wei,William,Walter,Werner,Wendy,Xin,Xiaoli,Xing,Xuan,Yan,Ying,Yu,Yusuf,Yaritza,Zhen,Zaw,Zin,Zhihong,Zahra";
    private const string LastNames =
        "Smith,Johnson,Williams,Brown,Jones,Garcia,Miller,Davis,Rodriguez,Martinez,Hernandez,Lopez,Gonzalez,Wilson,Anderson,Thomas,Taylor,Moore,Jackson,Martin,Novak,Good,Madden,Mccann,Terrell,Jarvis,Dickson,Reyna,Cantrell,Mayo,Branch,Hendrix,Rollins,Rowland,Whitney,Duke,Odom,Daugherty,Travis,Tang,Archer,Well,Waters,Logan,Camacho,Strickland,Norman,Person,Parsons,Frank,Harrington,Glover,Osborne,Buchanan,Casey,Floyd,Patton,Ibarra,Ball,Tyler,Suarez,Watkins,Greene,Wheeler,Valdez,Harper,Burke,Larson,Santiago,Maldonado,Morrison,Franklin,Carlson,Austin,Dominguez,Carr,Lawson,Jacobs,Obrien,Lynch,Singh,Eaton,Blackwell,Dyer,Prince ,Macdonald,Solomon,Guevara,Stafford,English,Hurst,Woodard,Cortes,Shannon,Kemp,Nolan,Mccullough,Merritt,Murillo,Moon,Salgado,Strong";

    private static readonly string[] FirstNameArray = FirstNames.Split(',');
    private static readonly string[] LastNameArray = LastNames.Split(',');

    /// <summary>
    /// Returns a random name from the constant string of first names and last
    /// names
    /// </summary>
    /// <returns>A string representing a random name.</returns>
    public static string GetRandomName()
    {
        string firstName =
            FirstNameArray[Random.Range(0, FirstNameArray.Length)];
        string lastName =
            LastNameArray[Random.Range(0, LastNameArray.Length)];
        return (firstName + " " + lastName);
    }
}
