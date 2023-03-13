import React, { useState } from 'react';
import { connect, useDispatch } from 'react-redux';
import { useRouter } from 'next/router';
import { Modal } from 'antd';
import useEcomerce from '~/hooks/useEcomerce';
import CartRepository from '~/repositories/CartRepository';
import { notification } from 'antd';
import { redirect } from 'next/dist/server/api-utils';
const ModuleDetailShoppingActions = ({
    ecomerce,
    product,
    extended = false,
}) => {
    const [quantity, setQuantity] = useState(1);
    const Router = useRouter();
    const { addItem } = useEcomerce();
    function handleAddItemToCart(e) {
        e.preventDefault();
        const userInfo = JSON.parse(localStorage.getItem('account'));
        if (userInfo) {
            let payload = {};
            payload.productId = product.id;
            payload.quantity = quantity;
            payload.name = userInfo.name;
            payload.description = '';
            const result = CartRepository.addToCart(payload);
            if (result) {
                notification['success']({
                    message: 'Success',
                    description: 'Add to cart Success',
                });
            }
            addItem(
                { id: product.id, quantity: quantity },
                ecomerce.cartItems,
                'cart'
            );
        } else {
            notification['warning']({
                message: 'Add To Cart Failed',
                description: 'You must login',
            });
        }
    }

    const handleAddItemToCompare = (e) => {
        e.preventDefault();
        e.preventDefault();
        addItem({ id: product.id }, ecomerce.compareItems, 'compare');
        const modal = Modal.success({
            centered: true,
            title: 'Success!',
            content: `This product has been added to compare listing!`,
        });
        modal.update;
    };

    const handleAddItemToWishlist = (e) => {
        e.preventDefault();
        addItem({ id: product.id }, ecomerce.wishlistItems, 'wishlist');
        const modal = Modal.success({
            centered: true,
            title: 'Success!',
            content: `This item has been added to your wishlist`,
        });
        modal.update;
    };

    function handleIncreaseItemQty(e) {
        e.preventDefault();
        setQuantity(quantity + 1);
    }

    function handleDecreaseItemQty(e) {
        e.preventDefault();
        if (quantity > 1) {
            setQuantity(quantity - 1);
        }
    }
    if (!extended) {
        return (
            <div className="ps-product__shopping">
                <figure>
                    <figcaption>Quantity</figcaption>
                    <div className="form-group--number">
                        <button
                            className="up"
                            onClick={(e) => handleIncreaseItemQty(e)}>
                            <i className="fa fa-plus"></i>
                        </button>
                        <button
                            className="down"
                            onClick={(e) => handleDecreaseItemQty(e)}>
                            <i className="fa fa-minus"></i>
                        </button>
                        <input
                            className="form-control"
                            type="text"
                            placeholder={quantity}
                            disabled
                        />
                    </div>
                </figure>
                <a
                    className="ps-btn ps-btn--black"
                    href="#"
                    onClick={(e) => handleAddItemToCart(e)}>
                    Add to cart
                </a>
                <div className="ps-product__actions">
                    <a href="#" onClick={(e) => handleAddItemToWishlist(e)}>
                        <i className="icon-heart"></i>
                    </a>
                    <a href="#" onClick={(e) => handleAddItemToCompare(e)}>
                        <i className="icon-chart-bars"></i>
                    </a>
                </div>
            </div>
        );
    } else {
        return (
            <div className="ps-product__shopping extend">
                {product.quantity > 0 ? (
                    <div className="ps-product__btn-group">
                        <figure>
                            <figcaption>Quantity</figcaption>
                            <div className="form-group--number">
                                <button
                                    className="up"
                                    onClick={(e) => handleIncreaseItemQty(e)}>
                                    <i className="fa fa-plus"></i>
                                </button>
                                <button
                                    className="down"
                                    onClick={(e) => handleDecreaseItemQty(e)}>
                                    <i className="fa fa-minus"></i>
                                </button>
                                <input
                                    className="form-control"
                                    type="text"
                                    placeholder={quantity}
                                    disabled
                                />
                            </div>
                        </figure>
                        <a
                            className="ps-btn ps-btn--black"
                            href="#"
                            onClick={(e) => handleAddItemToCart(e)}>
                            Add to cart
                        </a>
                        <div className="ps-product__actions">
                            <a
                                href="#"
                                onClick={(e) => handleAddItemToWishlist(e)}>
                                <i className="icon-heart"></i>
                            </a>
                            <a
                                href="#"
                                onClick={(e) => handleAddItemToCompare(e)}>
                                <i className="icon-chart-bars"></i>
                            </a>
                        </div>
                    </div>
                ) : (
                    <strong>Product is out of stock</strong>
                )}
            </div>
        );
    }
};

export default connect((state) => state)(ModuleDetailShoppingActions);
