import { BaseAPI } from "./base";

export class UserAPI {
    static async registerUser(email, phoneNumber, firstName, lastName, middleName, role, isBlocked) {
        return await BaseAPI.post("user/register", { email, phoneNumber, firstName, lastName, middleName, role, isBlocked });
    }
}