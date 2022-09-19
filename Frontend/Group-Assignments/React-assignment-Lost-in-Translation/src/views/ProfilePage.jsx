import { useNavigate } from 'react-router-dom'
import { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { getTranslations, resetTranslations } from '../store/actions/translationActions';

export function ProfilePage(props) {
 
    const navigateTo = useNavigate();
    const dispatch = useDispatch();
    useEffect(()=>{
        if (props.username === ""){
            navigateTo("/")
        }
    })
    const clearAllData = () => {
        dispatch(resetTranslations(props.username))

        props.setTranslations([]);
    }
    const toHTML = (previousTranslations) => {
        let htmlArr = []
        for (let i = 0; i < previousTranslations.length; i++) {
            if (previousTranslations[i]===""){
                continue;
            }
            htmlArr.push((
                <>
                    <div key={i}>{previousTranslations[i]}</div>
                    <br />
                </>

            ))
        }
        return htmlArr;
    }
    const goToLogin = function () {
        props.setUsername("");
        props.setTranslations([]);
        navigateTo("/")
    }
    const goToTranslation = function () {
        navigateTo("/Translation/")
    }
    return (
        <div>
            <h2>
                {props.username}'s Profile page

            </h2>
            <div>{toHTML(props.translations)}</div>
            <br />
            <button onClick={clearAllData}>
                Clear all translations
            </button>
            <button onClick={goToLogin}>
                Sign out
            </button>
            <button onClick={goToTranslation}>
                Translate
            </button>
        </div>
    )
}