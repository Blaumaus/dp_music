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
        compositions, compositionFile, disableField, isAdmin, selectedComposition,
        handleButtonBackClick, handleCompositionItemClick, onPlayed, handleSortAlphabetically, buttonsback } = props

    const today = new Date(Date.now());
    const validationSchema = yup.object({
        name: yup.string()
            .required("Введіть Назву"),
        description: yup.string(),

    });

    const handleFieldChange = (event) => {
        const fieldName = event.target.name;
        const fieldValue = event.target.value;
        onChange(fieldName, fieldValue);
    };
    return (
        <div>
            <CssBaseline />
            <div className={classes.buttonsBackContainer}>
                <Breadcrumbs separator={<ArrowForwardIosIcon fontSize="small" />}>
                    {buttonsback.map(button => {
                        return <Button component={Link} to={button.link}>
                            {button.name}
                        </Button>
                    })}
                </Breadcrumbs>
            </div>
            {isAdmin ? (<div>{selectedComposition ?
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
                                        elevation={1}
                                        width="100%"
                                        variation="primary"
                                        download={true}
                                        order="standart"
                                        preload="auto"
                                        autoplay={autoplay}
                                        src={compositionFile}
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
                            <AudioPlayer
                                elevation={1}
                                width="100%"
                                variation="primary"
                                download={true}
                                order="standart"
                                preload="auto"
                                autoplay={autoplay}
                                src={compositionToPlay.compositionFile}
                                loop={true}
                            />

                        </div>
                    }
                    <Grid container item xs={12} sm={9} className={classes.compositonsActionsContainer}>
                        <SortByAlphaIcon onClick={handleSortAlphabetically} color="secondary" className={classes.compositonsActions} />
                        <SortIcon color="secondary" className={classes.compositonsActions} />
                    </Grid>


                    {compositions.map(composition => {
                        return <Grid container className={classes.audioPlayerCompositionName} key={composition.id}>
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
    );
}
export default Composition;