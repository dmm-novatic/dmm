import Repository, { baseUrl } from './Repository';
import Utils from '~/utils/Utils';
class ProudctCategory{
    async getCategoryFull() {
        try {
            const response = await Repository.get(
                `${baseUrl}/productCategory/api/list`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
}
export default new ProudctCategory();