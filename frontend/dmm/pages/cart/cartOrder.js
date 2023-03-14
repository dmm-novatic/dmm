import React, { useEffect, useState } from 'react';
import CartTable from '~/components/elements/cart/CartTable';
import PageContainer from '~/components/layouts/PageContainer';
import CartRepository from '~/repositories/CartRepository';
import { ClipLoader } from 'react-spinners';
const cartOrder = ({}) => {
    const [listShop, setListShop] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const getListCart = async () => {
        setIsLoading(false);
        const result = await CartRepository.getListCart();
        if (result && result.length > 0 && result[0].shopId) {
            const datasShop = [];
            const data = Object.values(result);
            const listShops = data.map((item) => {
                let shopDetail = {};
                shopDetail.name = item.shopName;
                shopDetail.id = item.shopId;
                return shopDetail;
            });
            const uniqueIds = [];
            listShops = listShops.filter((element) => {
                const isDuplicate = uniqueIds.includes(element.id);
                if (!isDuplicate) {
                    uniqueIds.push(element.id);
                    return true;
                }
                return false;
            });
            listShops.map((item) => {
                let shopList = data
                    .filter((shop) => shop.shopId === item.id)
                    .map((item) => {
                        let newItem = item;
                        newItem.isChecked = false;
                        return newItem;
                    });
                let dataShop = {};
                dataShop.shopId = item.id;
                dataShop.shopName = item.name;
                dataShop.voucher = null;
                dataShop.shopItem = shopList;
                datasShop.push(dataShop);
            });
            setListShop(datasShop);
            localStorage.setItem('cart', datasShop);
        } else {
            setListShop([1]);
        }
        setIsLoading(true);
    };
    useEffect(() => {
        if (listShop.length === 0) {
            getListCart();
        }
    });
    return (
        <PageContainer title="Cart">
            {!isLoading ? (
                <div
                    style={{
                        width: '100%',
                        display: 'flex',
                        alignItems: 'center',
                        marginTop: '40px',
                        flexDirection: 'column',
                    }}>
                    <ClipLoader color="#fcb800"></ClipLoader>
                    <h4 style={{ marginTop: '30px', color: '#fcb800' }}>
                        Is Loading
                    </h4>
                </div>
            ) : listShop.length !== 0 && listShop[0].shopId ? (
                <CartTable source={listShop} getListCart={getListCart} />
            ) : (
                <div
                    style={{
                        width: '100%',
                        display: 'flex',
                        alignItems: 'center',
                        justifyContent: 'center',
                        height: '500px',
                    }}>
                    Chưa có sản phẩm
                </div>
            )}
        </PageContainer>
    );
};
export default cartOrder;
