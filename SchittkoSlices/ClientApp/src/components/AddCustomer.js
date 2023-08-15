import React from 'react';
import { Formik, Form, Field } from 'formik';
import * as Yup from 'yup';
import ApiRequestHandler from "../ApiRequestHandler";

const SignupSchema = Yup.object().shape({
    name: Yup.string()
        .min(2, 'Too Short!')
        .max(50, 'Too Long!')
        .required('Required'),
    address: Yup.string()
        .min(2, 'Too Short!')
        .max(50, 'Too Long!')
        .required('Required'),
    phone: Yup.string().required('Required'),
});

export const AddCustomer = ({ addCustomer }) => (
    <div>
        <h1>Welcome New Customer</h1>
        <Formik
            initialValues={{
                name: '',
                address: '',
                phone: '',
            }}
            validationSchema={SignupSchema}
                onSubmit = { async(values, { setSubmitting, resetForm }) => {
                const {username, address, phone} = values;
                    await ApiRequestHandler.addCustomer({username, address, phone});
                setSubmitting(false);
                resetForm();
            }}
        >
        {({ formik, errors, touched }) => (
            <Form>
                <Field name="name" />
                {errors.name && touched.name ? (
                    <div>{errors.name}</div>
                ) : null}
                <Field name="address" />
                {errors.address && touched.address ? (
                    <div>{errors.address}</div>
                ) : null}
                <Field name="phone" type="phone" />
                {errors.phone && touched.phone ? <div>{errors.phone}</div> : null}
                <button type="submit">Submit</button>
            </Form>
        )}
    </Formik>
    </div >
);