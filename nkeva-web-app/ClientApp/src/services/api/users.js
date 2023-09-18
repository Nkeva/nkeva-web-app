import { BaseAPI } from "./base";

export class UserAPI {
    static async registerUser(email, phoneNumber, firstName, lastName, middleName, role, isBlocked) {
        return await BaseAPI.post("user/register", { email, phoneNumber, firstName, lastName, middleName, role, isBlocked });
    }

    static async getSelfUser() {
        return await BaseAPI.get("user/self");
    }

    static async sendResetUserPasswordEmail(address) {
        return await BaseAPI.post(`user/reset-password-email`, address);
    }

    static async resetUserPassword(userId, password) {
        return await BaseAPI.put(`user/${userId}/password`, password);
    }
}