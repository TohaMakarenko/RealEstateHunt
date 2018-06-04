<template>
    <h1>{{text}}</h1>
</template>
<script>
    define(['Vue'], function(Vue){
        return {
            template: template,
            data: function () {
               return {
                   text: '123'
               } 
            }};
    });
</script>