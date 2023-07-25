import { BaseAPI } from "./base";

export class AuthAPI {
    static async login(email, password) {
        return await BaseAPI.post('auth/login', { email, password });
    }

    static async logout() {
        return await BaseAPI.get('auth/logout');
    }

    static async check() {
        return await BaseAPI.get('auth/check');
    }
}