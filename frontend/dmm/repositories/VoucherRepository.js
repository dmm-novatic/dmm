import Repository, { baseUrl } from './Repository';
import Utils from '~/utils/Utils';
class VoucherRepository {
    async getVoucherByCode(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            var endPoint = `/voucher/api/GetByCode?CodeVoucher=${payload.voucherCode}`;
            if (payload.shopId) {
                endPoint += `&ShopID=${payload.shopId}`;
            }
            const response = await Repository.get(`${baseUrl}` + endPoint
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
}
export default new VoucherRepository();
