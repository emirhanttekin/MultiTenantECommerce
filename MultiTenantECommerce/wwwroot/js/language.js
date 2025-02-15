
    function changeLanguage(lang) {
        document.cookie = "selectedLanguage=" + lang + "; path=/; expires=" + new Date(new Date().getTime() + 365 * 24 * 60 * 60 * 1000).toUTCString();
    location.reload(); 
                        }

    function getLanguageFromCookie() {
        let cookies = document.cookie.split('; ');
    for (let i = 0; i < cookies.length; i++) {
        let parts = cookies[i].split('=');
    if (parts[0] === "selectedLanguage") {
                                    return parts[1];
                                }
                            }
    return "tr";
                        }

    function updateLanguageUI() {
        let lang = getLanguageFromCookie();
    let flagSrc = lang === "en" ? "/images/flags/eng.png" : "/images/flags/tr.png";
    let langText = lang === "en" ? "ENG" : "TR";

    document.getElementById("selectedFlag").src = flagSrc;
    document.getElementById("selectedLangText").innerText = langText;
                        }

    updateLanguageUI();
