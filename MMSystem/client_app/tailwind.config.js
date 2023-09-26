/** @type {import('tailwindcss').Config} */

const colors = require('tailwindcss/colors')

module.exports = {
    content: [
        "./index.html",
        "./src/**/*.{vue,js,ts,jsx,tsx}",
    ],
    theme: {
        fontFamily: {
            'sans': ['Tajawal'],
        },
        screens: {
            'xs': '426px',
            'sm': '640px',
            'md': '800px',
            'lg': '1024px',
            'xl': '1280px',
            '2xl': '1440px',
            '3xl': '1920px',
            '4xl': '2560px',
        },
        extend: {

            width: {
                '1/9': '11.1111%',
                '2/9': '22.2222%',
            },

            minHeight: {
                32: '10rem',
                64: '17.6rem'
            },

            maxHeight: {
                64: '17.6rem'
            },

            maxWidth: {
                '10/12': '83.33%',
            },
            colors: {
                cyan: colors.cyan,
            },

            height: {
                'screen-75': '75vh',
                'screen-85': '85vh',
                'screen-93': '93vh',
                'screen-100': '100vh',
            },

            animation: {
                'arrow': 'arrow-effect .6s infinite',
                'spin-once': 'spin .5s linear',
                'bounce-slow': 'bounce-slow .9s infinite',
                'translate3D-1': 'translate3D-1 27s infinite',
                'translate3D-2': 'translate3D-2 30s infinite',
                'rotate-1': 'rotate-1 22s infinite',
                'rotate-2': 'rotate-2 25s infinite',

                'ping-slow': 'ping 1.1s linear infinite',
            },
            keyframes: {
                'arrow-effect': {
                    '0%, 100%': { transform: 'translateX(0)' },
                    '50%': { transform: 'translateX(-80%)' },
                },
                'bounce-slow': {
                    '0%, 100%': {
                        transform: 'translateY(0)',
                        animationTimingFunction: 'cubic-bezier(0, 0, 0, 1)'
                    },
                    '50%': {
                        transform: 'translateY(-10%)',
                        animationTimingFunction: 'cubic-bezier(0.8, 0, 1, 1)'
                    },
                },

                'translate3D-1': {
                    '0%, 100%': { transform: 'translate3D(0, 0, 0)' },
                    '50%': { transform: 'translate3D(100px, -100px, 0);' },
                },
                'translate3D-2': {
                    '0%, 100%': { transform: 'translate3D(0, 0, 0)' },
                    '50%': { transform: 'translate3D(-100px, 100px, 0);' },
                },

                'rotate-1': {
                    '0%, 100%': { transform: ' rotate(0deg) translateX(40px) rotate(0deg);' },
                    '50%': { transform: 'rotate(360deg) translateX(40px) rotate(-360deg);' }
                },
                'rotate-2': {
                    '0%, 100%': { transform: 'rotate(360deg) translateX(70px) rotate(-360deg);' },
                    '50%': { transform: ' rotate(0deg) translateX(70px) rotate(0deg);' }
                },
            },
        },
    },
    variants: {
        extend: {
            display: ['group-hover'],
            fontWeight: ['hover'],
            strokeWidth: ['group-hover'],
        },
    },
    plugins: [],
    corePlugins: {
        container: false,
    }
}