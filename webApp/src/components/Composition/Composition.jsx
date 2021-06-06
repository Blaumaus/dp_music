import React, { useState, useEffect } from "react";
import useStyles from "../EntityPageComponents.styles"
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import { Formik, Form, ErrorMessage } from 'formik'
import * as yup from 'yup';
import TextField from '@material-ui/core/TextField';
import CssBaseline from '@material-ui/core/CssBaseline';
import Avatar from '@material-ui/core/Avatar';
import IconButton from '@material-ui/core/IconButton';
import PhotoCamera from '@material-ui/icons/PhotoCamera';
import MainAdminMenu from 'components/MainAdminMenu/MainAdminMenu'
import AudioPlayer from 'material-ui-audio-player';
import Typography from '@material-ui/core/Typography';
import AddCircleOutlineIcon from '@material-ui/icons/AddCircleOutline';
import ThumbUpAltIcon from '@material-ui/icons/ThumbUpAlt';
import ThumbDownIcon from '@material-ui/icons/ThumbDown';
import SortByAlphaIcon from '@material-ui/icons/SortByAlpha';
import SortIcon from '@material-ui/icons/Sort';
import MusicNoteIcon from '@material-ui/icons/MusicNote';
import { Link } from 'react-router-dom';
import Breadcrumbs from '@material-ui/core/Breadcrumbs';
import ArrowForwardIosIcon from '@material-ui/icons/ArrowForwardIos';
import Select from '@material-ui/core/Select';
import InputLabel from '@material-ui/core/InputLabel';
import FormControl from '@material-ui/core/FormControl';

const Composition = props => {
    const classes = useStyles()
    const [compositionToPlay, setCompositonToPlay] = useState(null);
    const [isLoading, setIsLoading] = useState(true);
    const [autoplay, setAutoplay] = useState(false)

    useEffect(() => {
        setCompositonToPlay(compositions[0])
        setIsLoading(false)
    }, []);

    const onCompositionClick = composition => {
        setIsLoading(true);
        setCompositonToPlay(composition);
        setAutoplay(true);
        setIsLoading(false);
    }

    const { handleUpload, onChange, handleClickCreate,
        handleClickEdit, handleClickDelete, handleSubmit,
        compositions, compositionfileToView, disableField, selectedComposition,
        handleButtonBackClick, handleCompositionItemClick, handleSortAlphabetically, buttonsback,
        bands, genres, albums, user, onChangeGenreSelector, onChangeBandSelector } = props

    const today = new Date(Date.now());
    const validationSchema = yup.object({
        name: yup.string()
            .required("Введіть Назву"),
        year: yup.number().required('Введіть рік виходу')
            .min(1900, 'Рік повинен бути не менше 1900').max(today.getFullYear(), 'Рік повинен не більший ніж поточний'),
        description: yup.string(),

    });

    const handleFieldChange = (event) => {
        const fieldName = event.target.name;
        const fieldValue = event.target.value;
        onChange(fieldName, fieldValue);
    };

    const handleGenreSelectorValueChange = (event) => {
        const fieldName = event.target.name;
        const fieldValue = event.target.value;
        onChangeGenreSelector(fieldName, fieldValue)
    }

    const handleBandSelectorValueChange = (event) => {
        const fieldName = event.target.name;
        const fieldValue = event.target.value;
        onChangeBandSelector(fieldName, fieldValue)
    }

    return (
        <CssBaseline>
            <div style={{ padding: '1em' }}>
                <div className={classes.buttonsBackContainer}>
                    <Breadcrumbs separator={<ArrowForwardIosIcon fontSize="small" />}>
                        {buttonsback.map(button => {
                            return <Button component={Link} to={button.link}>
                                {button.name}
                            </Button>
                        })}
                    </Breadcrumbs>
                </div>
                {user.role === 'Admin' ? (<div>{selectedComposition ?
                    (<div className={classes.paperForm}>

                        <Formik className={classes.form}
                            initialValues={{ ...selectedComposition }}
                            validationSchema={validationSchema}
                            onSubmit={handleSubmit}
                            enableReinitialize={true}
                        >
                            {({ handleSubmit, values, touched, errors }) => (
                                <Form onSubmit={handleSubmit}>

                                    <div>
                                        <AudioPlayer
                                            width='auto'
                                            elevation={1}
                                            variation="primary"
                                            download={true}
                                            order="standart"
                                            preload="auto"
                                            autoplay={autoplay}
                                            src={compositionfileToView}
                                            loop={true}
                                        />
                                        <input
                                            accept="audio/*"
                                            className={classes.input}
                                            id="icon-button-file"
                                            multiple
                                            type="file"
                                            name="composition"
                                            onChange={handleUpload}
                                            disabled={disableField}

                                        />
                                        <label htmlFor="icon-button-file">
                                            <div className={classes.addCompositionButton}>
                                                <MusicNoteIcon className={classes.addCompositionButton} color="primary" />
                                            </div>
                                        </label>

                                    </div>
                                    <Grid container spacing={2}>
                                        <Grid item xs={12} sm={6}>
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
                                        <Grid item xs={12} sm={6}>
                                            <TextField
                                                onChange={handleFieldChange}
                                                name="year"
                                                variant="outlined"
                                                value={values.year}
                                                label="Рік випуску"
                                                disabled={disableField}
                                                fullWidth
                                                error={touched.year && Boolean(errors.year)}
                                                helperText={touched.year && errors.year}

                                            />
                                        </Grid>
                                        <Grid item xs={12} sm={4}>
                                            <FormControl variant="outlined" fullWidth style={{ marginTop: '1em' }}>
                                                <InputLabel style={{ marginTop: '-0.5em' }} htmlFor="genreId">Жанр</InputLabel>
                                                <Select
                                                    native
                                                    id="genreId"
                                                    name="genreId"
                                                    value={values.genreId ? values.genreId : genres[0].id}
                                                    onChange={handleGenreSelectorValueChange}
                                                    fullWidth
                                                    disabled={disableField}
                                                >
                                                    {genres.map(genre => {
                                                        return <option key={genre.name} value={genre.id}>{genre.name}</option>
                                                    })}
                                                </Select>
                                            </FormControl>
                                        </Grid>
                                        <Grid item xs={12} sm={4}>
                                            <FormControl variant="outlined" fullWidth style={{ marginTop: '1em' }}>
                                                <InputLabel style={{ marginTop: '-0.5em' }} htmlFor="bandId">Група</InputLabel>
                                                <Select
                                                    native
                                                    id="bandId"
                                                    name="bandId"
                                                    value={values.bandId ? values.bandId : bands[0].id}
                                                    onChange={handleBandSelectorValueChange}
                                                    fullWidth
                                                    disabled={disableField}
                                                >
                                                    {bands.map(band => {
                                                        return <option key={band.name} value={band.id}>{band.name}</option>
                                                    })}
                                                </Select>
                                            </FormControl>
                                        </Grid>
                                        <Grid item xs={12} sm={4}>
                                            <FormControl variant="outlined" fullWidth style={{ marginTop: '1em' }}>
                                                <InputLabel style={{ marginTop: '-0.5em' }} htmlFor="albumId">Альбом</InputLabel>
                                                <Select
                                                    native
                                                    id="albumId"
                                                    name="albumId"
                                                    value={values.albumId ? values.albumId : albums[0].id}
                                                    onChange={handleFieldChange}
                                                    fullWidth
                                                    disabled={disableField}
                                                >
                                                    {albums.map(album => {
                                                        return <option key={album.name} value={album.id}>{album.name}</option>
                                                    })}
                                                </Select>
                                            </FormControl>
                                        </Grid>
                                        <Grid item xs={12}>
                                            <TextField
                                                onChange={handleFieldChange}
                                                name="lyrics"
                                                label="Текст"
                                                value={values.lyrics}
                                                placeholder="Текст"
                                                variant="outlined"
                                                multiline
                                                disabled={disableField}
                                                fullWidth
                                                rows={3}
                                                rowsMax={10}
                                                error={touched.lyrics && Boolean(errors.lyrics)}
                                                helperText={touched.lyrics && errors.lyrics}
                                            />
                                        </Grid>
                                        <Grid item xs={12}>
                                            <TextField
                                                onChange={handleFieldChange}
                                                name="description"
                                                label="Опис"
                                                value={values.description}
                                                placeholder="Опис"
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
                                    <div className={classes.buttonsFormContainer}>
                                        <div className={classes.buttonSubmitContainer}>
                                            <Button
                                                type="submit"
                                                fullWidth
                                                variant="contained"
                                                color="primary"
                                                className={classes.submit}
                                            >
                                                Підтвердити
                               </Button>
                                        </div>
                                        <div className={classes.buttonBackContainer}>
                                            <Button variant="contained" fullWidth className={classes.buttonBack} onClick={handleButtonBackClick}>
                                                Назад
                               </Button>
                                        </div>
                                    </div>
                                </Form>

                            )}
                        </Formik>
                    </div>)
                    : (
                        <MainAdminMenu
                            items={compositions}
                            onClickCreate={handleClickCreate}
                            onClickEdit={handleClickEdit}
                            onClickDelete={handleClickDelete}
                            onClickItem={handleCompositionItemClick}
                        />
                    )
                }
                </div>) : (
                    <div>
                        {!isLoading &&
                            <div className={classes.audioPlayer}>
                                <div className={classes.audioPlayerCompositionName}>
                                    <Typography variant="h5">
                                        {compositionToPlay.name}
                                    </Typography>
                                </div>
                                <div>
                                    <AudioPlayer
                                        elevation={1}
                                        width='auto'
                                        variation="primary"
                                        download={true}
                                        order="standart"
                                        preload="auto"
                                        autoplay={autoplay}
                                        src={compositionToPlay.compositionFile}
                                        loop={true}
                                    />

                                </div>
                            </div>
                        }
                        <Grid container item xs={12} sm={9} className={classes.compositonsActionsContainer}>
                            <SortByAlphaIcon onClick={handleSortAlphabetically} color="secondary" className={classes.compositonsActions} />
                            <SortIcon color="secondary" className={classes.compositonsActions} />
                        </Grid>


                        {compositions.map(composition => {
                            return <Grid container className={classes.compositionName} key={composition.id}>
                                <Grid item xs={12} sm={9} >
                                    <Button className={classes.listItem} variant="outlined" fullWidth onClick={() => { onCompositionClick(composition) }}>{composition.name}  </Button>
                                </Grid>
                                <Grid item xs={4} sm={1} className={classes.compositionIcons}>
                                    <AddCircleOutlineIcon className={classes.addToPlaylistIcon} color="primary" />
                                </Grid>
                                <Grid item xs={4} sm={1} className={classes.compositionIcons}>
                                    <ThumbUpAltIcon className={classes.addToPlaylistIcon} color="primary" />
                                </Grid>
                                <Grid item xs={4} sm={1} className={classes.compositionIcons}>
                                    <ThumbDownIcon className={classes.addToPlaylistIcon} color="primary" />
                                </Grid>

                            </Grid>
                        })}

                    </div>)
                }

            </div >
        </CssBaseline>

    );
}
export default Composition;