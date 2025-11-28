using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using System; // 時間用

public class WeatherText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI weatherText;
    [SerializeField] Image weatherIcon;

    // アイコン
    [Header("Day Icons")]
    public Sprite sunnySprite;
    public Sprite cloudySprite;
    public Sprite rainSprite;
    public Sprite snowSprite;
    public Sprite thunderSprite;
    public Sprite typhoonSprite;

    [Header("Night Icons")]
    public Sprite nightSunnySprite;
    public Sprite nightCloudySprite;
    public Sprite nightRainSprite;
    public Sprite nightSnowSprite;
    public Sprite nightThunderSprite;
    public Sprite nightTyphoonSprite;

    public Sprite defaultSprite;

    private string apiKey = "0bfc19eb159b0430b4cfb19f9bd6243f";

    void Start()
    {
        StartCoroutine(GetCityAndWeather());
    }

    IEnumerator GetCityAndWeather()
    {
        string ipUrl = "https://ipinfo.io/json";

        UnityWebRequest ipRequest = UnityWebRequest.Get(ipUrl);
        yield return ipRequest.SendWebRequest();

        if (ipRequest.result != UnityWebRequest.Result.Success)
        {
            weatherText.text = "位置情報取得に失敗しました";
            yield break;
        }

        IPInfo data = JsonUtility.FromJson<IPInfo>(ipRequest.downloadHandler.text);

        string[] latlon = data.loc.Split(',');
        float lat = float.Parse(latlon[0]);
        float lon = float.Parse(latlon[1]);

        // 天気所得
        string url =
            $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&lang=ja&units=metric";

        UnityWebRequest req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            WeatherData weather = JsonUtility.FromJson<WeatherData>(req.downloadHandler.text);

            weatherText.text =
                $"{weather.weather[0].description}";

            //台風チェック
            ChangeIcon(weather);
        }
        else
        {
            weatherText.text = "天気取得に失敗しました";
        }
    }

    [System.Serializable]
    public class IPInfo
    {
        public string city;
        public string region;
        public string loc;
    }

    // ------------- アイコン切り替え ---------------

    void ChangeIcon(WeatherData w)
    {
        bool isNight = IsNight();
        string main = w.weather[0].main;

        // ★台風判定（風速 + 雨 or 雷）
        if (IsTyphoon(w))
        {
            weatherIcon.sprite = isNight ? nightTyphoonSprite : typhoonSprite;
            return;
        }

        switch (main)
        {
            case "Clear":
                weatherIcon.sprite = isNight ? nightSunnySprite : sunnySprite;
                break;

            case "Clouds":
                weatherIcon.sprite = isNight ? nightCloudySprite : cloudySprite;
                break;

            case "Rain":
                weatherIcon.sprite = isNight ? nightRainSprite : rainSprite;
                break;

            case "Snow":
                weatherIcon.sprite = isNight ? nightSnowSprite : snowSprite;
                break;

            case "Thunderstorm":
                weatherIcon.sprite = isNight ? nightThunderSprite : thunderSprite;
                break;

            default:
                weatherIcon.sprite = defaultSprite;
                break;
        }
    }

    // ★台風判定（風速 15m/s 以上 + 雨 or 雷）
    bool IsTyphoon(WeatherData w)
    {
        if (w.wind.speed >= 15f)
        {
            string m = w.weather[0].main;
            if (m == "Rain" || m == "Thunderstorm")
                return true;
        }
        return false;
    }

    // 朝(6時)～夕方(18時)を昼
    bool IsNight()
    {
        int hour = DateTime.Now.Hour;
        return (hour < 6 || hour >= 18);
    }
}

// ------------------ JSON ------------------

[System.Serializable]
public class WeatherData
{
    public Weather[] weather;
    public Main main;
    public Wind wind; // ★台風判定のため追加
}

[System.Serializable]
public class Weather
{
    public string description;
    public string main;
}

[System.Serializable]
public class Main
{
    public float temp;
}

[System.Serializable]
public class Wind
{
    public float speed;
}
