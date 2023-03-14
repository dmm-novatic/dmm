import React, { useEffect, useState } from 'react';
import { generateTempArray } from '~/utilities/common-helpers';
import SkeletonProduct from '~/components/elements/skeletons/SkeletonProduct';
import Product from '~/components/elements/products/Product';
import useGetProducts from '~/hooks/useGetProducts';
import CollectionRepository from '~/repositories/CollectionRepository';
import ProductWide from '~/components/elements/products/ProductWide';
import { Pagination } from 'antd';

const AutopartRecommendForYou = ({ shopId = null, columns = 6 }) => {
    const [loading, setLoading] = useState(true);
    const [productItems, setProductItems] = useState(null);
    const [listView, setListView] = useState(true);
    const [totalProduct, setTotalProduct] = useState(null);
    const [page, setPage] = useState(1);
    const [classes, setClasses] = useState(
        'col-xl-4 col-lg-4 col-md-3 col-sm-6 col-6'
    );
    function handleSetColumns() {
        switch (columns) {
            case 2:
                setClasses('col-xl-6 col-lg-6 col-md-6 col-sm-6 col-6');
                return 3;
                break;
            case 4:
                setClasses('col-xl-3 col-lg-4 col-md-6 col-sm-6 col-6');
                return 4;
                break;
            case 6:
                setClasses('col-xl-2 col-lg-4 col-md-6 col-sm-6 col-6');
                return 6;
                break;

            default:
                setClasses('col-xl-4 col-lg-4 col-md-3 col-sm-6 col-6');
        }
    }
    const getProductByShopId = async (pageIndex) => {
        setLoading(true);
        const response = await CollectionRepository.getProductByShopId(
            shopId,
            pageIndex,
            20
        );
        if (response) {
            setProductItems(response.data);
            setTotalProduct(response.totalItem);
        }
        setLoading(false);
    };
    useEffect(() => {
        if (shopId) {
            getProductByShopId(1);
            if (totalProduct < 6) {
                setListView(false);
            } else {
                setListView(true);
            }
        }
        handleSetColumns();
    }, [shopId]);
    function handlePagination(e) {
        setPage(e);
        getProductByShopId(e);
    }
    function handleChangeViewMode(e) {
        e.preventDefault();
        setListView(!listView);
    }

    // Views
    let productItemsView;
    if (!loading) {
        if (productItems && productItems.length > 0) {
            if (listView) {
                const items = productItems.map((item) => (
                    <div className={classes} key={item.id}>
                        <Product product={item} />
                    </div>
                ));
                productItemsView = (
                    <div className="ps-shop-items">
                        <div className="row">{items}</div>
                    </div>
                );
            } else {
                productItemsView = productItems.map((item) => (
                    <ProductWide product={item} />
                ));
            }
        } else {
            productItemsView = <p>No product found.</p>;
        }
    } else {
        const skeletonItems = generateTempArray(12).map((item) => (
            <div className={classes} key={item}>
                <SkeletonProduct />
            </div>
        ));
        productItemsView = <div className="row">{skeletonItems}</div>;
    }

    return (
        <div className="ps-shopping" style={{ width: '90%' }}>
            <div className="ps-shopping__header">
                <h3>RECOMMENDED FOR YOU</h3>
                {totalProduct >= 6 && (
                    <div className="ps-shopping__actions">
                        <div className="ps-shopping__view">
                            <p>View</p>
                            <ul className="ps-tab-list">
                                <li
                                    className={
                                        listView === true ? 'active' : ''
                                    }>
                                    <a
                                        href="#"
                                        onClick={(e) =>
                                            handleChangeViewMode(e)
                                        }>
                                        <i className="icon-grid"></i>
                                    </a>
                                </li>
                                <li
                                    className={
                                        listView !== true ? 'active' : ''
                                    }>
                                    <a
                                        href="#"
                                        onClick={(e) =>
                                            handleChangeViewMode(e)
                                        }>
                                        <i className="icon-list4"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                )}
            </div>
            <div className="ps-shopping__content">{productItemsView}</div>
            <div className="ps-shopping__footer text-center">
                <div className="ps-pagination">
                    <Pagination
                        total={totalProduct && totalProduct}
                        pageSize={20}
                        responsive={true}
                        showSizeChanger={false}
                        current={page !== undefined ? parseInt(page) : 1}
                        onChange={(e) => handlePagination(e)}
                    />
                </div>
            </div>
        </div>
    );
};

export default AutopartRecommendForYou;
