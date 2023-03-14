import Repository, { baseUrl } from './Repository';
import Utils from '~/utils/Utils';
class ShopRepository {
    async getTop5Shop() {
        try {
            const result =await Repository.get(`${baseUrl}/shop/api/List/Top5`);
            const data = Utils.handleResponse(result);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
}
export default new ShopRepository();
