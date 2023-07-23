import { CookieManager } from "./CookieManager";

const fs = require('fs');

export class LanguageManager {
    static defaultLang = 'en';

    static get(key) {
        var lang = CookieManager.get('language');

        if (lang === null) {
            CookieManager.set('language', this.defaultLang);
            lang = this.defaultLang;
        }

        try {
            const jsonData = JSON.parse(fs.readFileSync(`../../public/strings/${lang}.json`, 'utf8'));
            return jsonData.hasOwnProperty(key) || typeof jsonData[key] === 'string' ? jsonData[key] : key;
        } catch (error) {
            console.error('Error reading or parsing JSON file:', error);
            return key;
        }
    }

    static getAsync(key) {
        var lang = CookieManager.get('language');

        if (lang === null) {
            CookieManager.set('language', this.defaultLang);
            lang = this.defaultLang;
        }

        fs.readFile(`../../public/strings/${lang}.json`, 'utf8', (err, data) => {
            if (err) {
                console.error('Error reading or parsing JSON file:', error);
            } else {
                const jsonData = JSON.parse(data);
                return jsonData.hasOwnProperty(key) || typeof jsonData[key] === 'string' ? jsonData[key] : key;
            }
        });
    }

    static setLang(lang) {
        if (fs.existsSync(`../../public/strings/${lang}.json`)) {
            CookieManager.set('language', lang, '/');
            return true;
        }
        
        return false;
    }

    static currentLang() {
        return CookieManager.get('language');
    }
}