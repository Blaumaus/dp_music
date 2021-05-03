import React, { useState } from "react";
import Typography from '@material-ui/core/Typography';
import useStyles from "../EntityPageComponents.styles"
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { Formik, Form, ErrorMessage } from 'formik'
import * as yup from 'yup';
import TextField from '@material-ui/core/TextField';
import CssBaseline from '@material-ui/core/CssBaseline';
import Avatar from '@material-ui/core/Avatar';
import IconButton from '@material-ui/core/IconButton';
import PhotoCamera from '@material-ui/icons/PhotoCamera';
import styles from './Bands.module.css';
import BandCard from 'components/EntityCard/EntityCard';
import MainAdminMenu from 'components/MainAdminMenu/MainAdminMenu'
import DateFnsUtils from '@date-io/date-fns';
import {
    MuiPickersUtilsProvider,
    KeyboardDatePicker,
} from '@material-ui/pickers';
const Band = props => {

    const classes = useStyles()

    const { handleUpload, onChange, handleClickCreate,
        handleClickEdit, handleClickDelete, handleSubmit,
        bands, file, disableField, isAdmin, selectedBand,
        handleButtonBackClick, handleBandItemClick } = props

    const today = new Date(Date.now());
    const validationSchema = yup.object({
        name: yup.string()
            .required("Введіть Назву"),
        description: yup.string(),
        countryCode: yup.string().matches(/^[a-zA-Z]*$/,"Не вірний формат").length(2,"Не вірний формат"),
        foundationDate: yup.date().max(today, 'Не може бути раніше сьогоднішньої'),

    });

    const handleFieldChange = (event) => {
        const fieldName = event.target.name;
        const fieldValue = event.target.value;
        onChange(fieldName, fieldValue);
    };
    const handleDateChange = (date) => {
        const fieldName = 'foundationDate';
        const fieldValue = date;
        onChange(fieldName, fieldValue);
    };

    return (
        <div>
            <CssBaseline />
            {isAdmin ? (<div>{selectedBand ?
                (<div className={classes.paperForm}>

                    <Formik className={classes.form}
                        initialValues={{ ...selectedBand }}
                        validationSchema={validationSchema}
                        onSubmit={handleSubmit}
                        enableReinitialize={true}
                    >
                        {({ handleSubmit, values, touched, errors }) => (
                            <Form onSubmit={handleSubmit}>

                                <div className={classes.upload}>
                                    <img src={file} className={classes.avatar} />
                                    <input
                                        accept="image/*"
                                        className={classes.input}
                                        id="icon-button-file"
                                        multiple
                                        type="file"
                                        name="avatar"
                                        onChange={handleUpload}
                                        disabled={disableField}

                                    />
                                    <label htmlFor="icon-button-file">
                                        <IconButton color="primary" aria-label="upload picture" component="span">
                                            <PhotoCamera />
                                        </IconButton>
                                    </label>

                                </div>
                                <Grid container spacing={2}>
                                    <Grid item xs={12}>
                                        <TextField
                                            onChange={handleFieldChange}
                                            name="name"
                                            variant="outlined"
                                            value={values.name}
                                            label="Назва"
                                            disabled={disableField}
                                            fullWidth
                                            error={touched.name && Boolean(errors.name)}
                                            helperText={touched.name && errors.name}

                                        />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <MuiPickersUtilsProvider utils={DateFnsUtils}>
                                            <KeyboardDatePicker
                                                disableToolbar
                                                variant="inline"
                                                format="MM/dd/yyyy"
                                                margin="normal"
                                                id="date-picker-inline"
                                                name="foundationDate"
                                                inputVariant="outlined"
                                                fullWidth
                                                disabled={disableField}
                                                label="Дата заснування"
                                                format="dd/MM/yyyy"
                                                value={values.foundationDate}
                                                InputAdornmentProps={{ position: "start" }}
                                                onChange={handleDateChange}
                                                error={touched.foundationDate && Boolean(errors.foundationDate)}
                                                helperText={touched.foundationDate && errors.foundationDate}
                                            />
                                        </MuiPickersUtilsProvider>
                                    </Grid>
                                    <Grid item xs={12}>
                                        <TextField
                                            onChange={handleFieldChange}
                                            name="countryCode"
                                            variant="outlined"
                                            value={values.countryCode}
                                            label="Код країни"
                                            disabled={disableField}
                                            fullWidth
                                            error={touched.countryCode && Boolean(errors.countryCode)}
                                            helperText={touched.countryCode && errors.countryCode}

                                        />
                                    </Grid>
                                    <Grid item xs={12}>
                                        <TextField
                                            onChange={handleFieldChange}
                                            name="description"
                                            label="Опис"
                                            value={values.description}
                                            placeholder="Description"
                                            variant="outlined"
                                            multiline
                                            disabled={disableField}
                                            fullWidth
                                            rows={3}
                                            rowsMax={10}
                                            error={touched.description && Boolean(errors.description)}
                                            helperText={touched.description && errors.description}
                                        />
                                    </Grid>

                                </Grid>

                                <Button
                                    type="submit"
                                    fullWidth
                                    variant="contained"
                                    color="primary"
                                    className={classes.submit}
                                >
                                    Підтвердити
                                </Button>
                                <Button variant="contained" className={classes.buttonBack} onClick={handleButtonBackClick}>
                                    Назад
                                </Button>
                            </Form>

                        )}
                    </Formik>
                </div>)
                : (
                    <MainAdminMenu
                        items={bands}
                        onClickCreate={handleClickCreate}
                        onClickEdit={handleClickEdit}
                        onClickDelete={handleClickDelete}
                        onClickItem={handleBandItemClick}
                    />
                )
            }
            </div>) : (
                <div className={styles.mediaContainer}>
                    {bands.map(band => {
                        return <BandCard
                            key={band.id}
                            name={band.name}
                            image={band.image}
                            description={band.description}
                            onClick={() => handleBandItemClick(band)}
                            id={band.id}
                        >
                        </BandCard>
                    })}

                </div>)}

        </div >
    );
}
export default Band;