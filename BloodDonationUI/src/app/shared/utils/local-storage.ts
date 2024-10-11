export class LocalStorageUtils {

    public setUserLocalData(response: any) {
        this.setUserToken(response.token)
    }

    public clearUserLocalData() {
        localStorage.removeItem('bloodDonation.token')
    }

    public getUserToken() {
        localStorage.getItem('bloodDonation.token')
    }

    public setUserToken(token: string) {
        localStorage.setItem('bloodDonation.token', token)
    }
}